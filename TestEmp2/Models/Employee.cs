using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestEmp2.Models
{
    public class Employee
    {   
       
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Must enter full name")]
        [StringLength(40,ErrorMessage = "Can not exceed 40 characters")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name="Office Email")]
        public string Email { get; set; }
        public string  AvatarPatch { get; set; }
        [Required]
        public Dept? Department { get; set; }
    }
}
