using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestEmp2.Models;

namespace TestEmp2.ViewModels
{
    public class HomeCreateViewModel
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Must enter full name")]
        [StringLength(40, ErrorMessage = "Can not exceed 40 characters")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Office Email")]
        public string Email { get; set; }
       public IFormFile Avatar { get; set; }
        [Required]
        public Dept? Department { get; set; }
    }
}
