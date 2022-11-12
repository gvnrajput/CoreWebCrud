using System;
using System.Collections.Generic;

#nullable disable

namespace CoreWebCrud.Models
{
    public partial class Department
    {
        public int DepId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
