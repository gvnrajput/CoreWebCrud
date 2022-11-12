using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebCrud.Models
{
    public class EmployeeValidator
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Employee Salary")]
        public decimal Salary { get; set; }

        [Required]
        [Display(Name = "Joining Date")]
        public decimal JoiningDate { get; set; }
    }

    [ModelMetadataType(typeof(EmployeeValidator))]
    public partial class Employee
    {
    }
}
