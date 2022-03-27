using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiFinalTask1.Models
{
    public class DepartmentStudentViewMode
    {
        public int id { get; set; }
        public int DepartmentId { get; set; }
        public int StudentId { get; set; }
    }
}