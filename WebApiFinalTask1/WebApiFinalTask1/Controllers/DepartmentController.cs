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
    public class DepartmentController : ApiController
    {
        public IHttpActionResult GetDepartmentList()
        {
            IList<DepartmentViewMode> students = null;
            using (var x = new FinalEntities())
            {
                students = x.Departments
                            .Select(s => new DepartmentViewMode()
                            {
                                id = s.id,
                                Name = s.Name,
                               
                            }).ToList<DepartmentViewMode>();
            }

            if (students.Count == 0)
                return NotFound();
            return Ok(students);

        }

        //add data
        public IHttpActionResult PostNewDepartment(DepartmentViewMode s)
        {
            if (!ModelState.IsValid)
                return BadRequest("invalid data");

            using (var x = new FinalEntities())
            {
                x.Departments.Add(new Department()
                {
                    id = s.id,
                    Name = s.Name,
    
                });

                x.SaveChanges();
            }
            return Ok();
        }

        //update data
        public IHttpActionResult PutDepartment(DepartmentViewMode stu)
        {
            if (!ModelState.IsValid)
                return BadRequest("invalid");
            using (var x = new FinalEntities())
            {
                var checkExistingDepartment = x.Departments.Where(s => s.id == stu.id).FirstOrDefault<Department>();
                if (checkExistingDepartment != null)
                {
                    checkExistingDepartment.id = stu.id;
                    checkExistingDepartment.Name = stu.Name;
                    
                    x.SaveChanges();

                }
                else
                    return NotFound();
            }
            return Ok();
        }

        //Delete
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Please enter valid id ");

            using (var x = new FinalEntities())
            {
                var student = x.Departments.Where(s => s.id == id).FirstOrDefault();
                x.Entry(student).State = System.Data.Entity.EntityState.Deleted;
                x.SaveChanges();
            }
            return Ok();
        }

    }
}
