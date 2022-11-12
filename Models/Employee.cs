using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CoreWebCrud.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        [Display(Name = "Employee Nm")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }
        public decimal Salary { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}
