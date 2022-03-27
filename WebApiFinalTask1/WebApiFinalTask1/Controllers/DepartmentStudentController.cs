using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiFinalTask1.Models;
using WebApiFinalTask1.Models.Database;

namespace WebApiFinalTask1.Controllers
{
    public class DepartmentStudentController : ApiController
    {
        public IHttpActionResult GetDepartmentStudentList()
        {
            IList<DepartmentStudentViewMode> students = null;
            using (var x = new FinalEntities())
            {
                students = x.DepartmentStudents
                            .Select(s => new DepartmentStudentViewMode()
                            {
                                id = s.id,
                                DepartmentId = s.DepartmentId,
                                StudentId = s.StudentId

                            }).ToList<DepartmentStudentViewMode>();
            }

            if (students.Count == 0)
                return NotFound();
            return Ok(students);

        }
    }
}
