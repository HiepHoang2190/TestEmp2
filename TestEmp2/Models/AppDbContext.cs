using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestEmp2.Models
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
                   new Employee()
                   {
                       AvatarPatch = "images/img_avatar1.png",
                       Department = Dept.IT,
                       Email = "hoangbachhiep2190@gmail.com",
                       Name = "hoangbachhiep",
                       EmployeeId = 1,
                       //Key=Guid.Parse("09002689-ebdf-4548-ab56-2549f482e12a")

                   },
                new Employee()
                {
                    AvatarPatch = "images/img_avatar5.png",
                    Department = Dept.HR,
                    Email = "lequangvu11@gmail.com",
                    Name = "lequangvu23",
                    EmployeeId = 2,

                },
                 new Employee()
                 {
                     AvatarPatch = "images/img_avatar5.png",
                     Department = Dept.PAYROLL,
                     Email = "lequangvu11@gmail.com",
                     Name = "lequangvu23",
                     EmployeeId = 3
                 },
                  new Employee()
                  {
                      AvatarPatch = "images/img_avatar5.png",
                      Department = Dept.SALE,
                      Email = "lequangvu11@gmail.com",
                      Name = "lequangvu23",
                      EmployeeId = 4
                  }

                );
                
                
                
               
        }
    }

}
