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
    public class StudentController : ApiController
    {
        public IHttpActionResult GetAllStudent()
        {
            IList<StudentViewModel> students = null;
            using (var x = new FinalEntities())
            {
                students = x.Students
                            .Select(s => new StudentViewModel()
                            {
                                id = s.id,
                                Name = s.Name,
                                DeptId = s.DeptId
                            }).ToList<StudentViewModel>();
            }

            if (students.Count == 0)
                return NotFound();
            return Ok(students);

        }
        //add data
        public IHttpActionResult PostNewStudent(StudentViewModel s)
        {
            if (!ModelState.IsValid)
                return BadRequest("invalid data");

            using (var x = new FinalEntities())
            {
                x.Students.Add(new Student()
                {
                    id = s.id,
                    Name = s.Name,
                    DeptId = s.DeptId
                });

                x.SaveChanges();
            }
            return Ok();
        }
        //update data
        public IHttpActionResult PutStudent(StudentViewModel stu)
        {
            if (!ModelState.IsValid)
                return BadRequest("invalid");
            using (var x = new FinalEntities())
            {
                var checkExistingStudent = x.Students.Where(s => s.id == stu.id).FirstOrDefault<Student>();
                if (checkExistingStudent != null)
                {
                    checkExistingStudent.id = stu.id;
                    checkExistingStudent.Name = stu.Name;
                    checkExistingStudent.DeptId = stu.DeptId;
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
                var student = x.Students.Where(s => s.id == id).FirstOrDefault();
                x.Entry(student).State = System.Data.Entity.EntityState.Deleted;
                x.SaveChanges();
            }
            return Ok();
        }
    
}
}
