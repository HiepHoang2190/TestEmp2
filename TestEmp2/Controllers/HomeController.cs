using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestEmp2.Models;
using TestEmp2.ViewModels;

namespace TestEmp2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(IEmployeeRepository employeeRepository,
                               IWebHostEnvironment webHostEnvironment)
        {
            this.employeeRepository = employeeRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

       /// <summary>
       /// sdsdsds
       /// sdsds
       /// sd
       /// sd
       /// </summary>
       /// <returns></returns>
       /// sđsds
       /// sđssd
       /// sddsdsđsdssdsdsdss
       /// sđs
       /// 
       /// 
       
       ///111111111111111111111111
      ///222222222222222222222
        public IActionResult Index()
        {
            var employee = employeeRepository.Gets();
            return View(employee);
        }
        public IActionResult Details(int id)
        {
            var employee = employeeRepository.Get(id);
            var detailViewModel = new HomeDetailViewModel()
            {
                employee = employee,
                TitleName = "Employee Detail"
            };
            return View(detailViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HomeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department
                };

                var fileName = string.Empty;
                if (model.Avatar != null)
                {
                    string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    fileName = $"{Guid.NewGuid()}_{model.Avatar.FileName}";
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using(var fs=new FileStream(filePath, FileMode.Create))
                    {
                        model.Avatar.CopyTo(fs);
                    }
                }
                employee.AvatarPatch = fileName;
                var newEmp = employeeRepository.Create(employee);
                return RedirectToAction("Details", new { id = newEmp.EmployeeId });

            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = employeeRepository.Get(id);
            var editEmp = new HomeEditViewModel()
            {
                AvatarPath = employee.AvatarPatch,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                Id = employee.EmployeeId
            };
            return View(editEmp);
        }
        [HttpPost]
        public IActionResult Edit(HomeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    EmployeeId = model.Id,
                    AvatarPatch = model.AvatarPath
                };
                var fileName = string.Empty;
                if (model.Avatar != null)
                {
                    string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    fileName = $"{Guid.NewGuid()}_{model.Avatar.FileName}";
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        model.Avatar.CopyTo(fs);
                    }
                    employee.AvatarPatch = fileName;
                    if (!string.IsNullOrEmpty(model.AvatarPath))
                    {
                        string delFile = Path.Combine(webHostEnvironment.WebRootPath, "images", model.AvatarPath);
                        System.IO.File.Delete(delFile);
                    }

                }
                var editEmp = employeeRepository.Edit(employee);
                if (editEmp != null)
                {
                    return RedirectToAction("Details", new { id = editEmp.EmployeeId });
                }
            }
            return View();

        }
        public IActionResult Delete(int id)
        {

            if (employeeRepository.Delete(id))
            {
                return RedirectToAction("Index");
            }
            return View();

        }


    }
}
