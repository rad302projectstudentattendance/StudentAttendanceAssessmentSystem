using AutoMapper;
using StudentAALibrary;
using StudentAAWebApi.DAL;
using StudentAAWebApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace StudentAAWebAPINew.Controllers
{
    [RoutePrefix("api/Students")]
    public class StudentsController :ApiController
    {
        private IStudentRepository studentRepo;

        public StudentsController()
        {
            studentRepo = new StudentRepository();
        }

        [Route()]
        public IEnumerable<StudentDTO> GetStudents()
        {

            var Students = studentRepo.GetAll();
            List<StudentDTO> StudentDTOs = new List<StudentDTO>();
            foreach (var Student in Students)
            {
                StudentDTOs.Add(Mapper.Map<StudentDTO>(Student));
            }


            return StudentDTOs;
        }

        [Route("Student/{id}")]  // GET: Api/Students/5
        [ResponseType(typeof(StudentDTO))]
        public IHttpActionResult GetStudent(int id)
        {
            Student Student = studentRepo.Get(id);
            if (Student == null)
            {
                return NotFound();
            }



            StudentDTO StudentDTO = Mapper.Map<StudentDTO>(Student);
            return Ok(StudentDTO);
        }



        // PUT: Api/Students/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, string studentID, string firstName, string lastName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var student = studentRepo.Get(id); 
            if (student == null)
            {
                return BadRequest();
            }

            if(studentID != null)
            student.StudentID = studentID;

            if (firstName != null)
                student.FirstName = firstName;
            if (lastName != null)
                student.LastName = lastName;

            
            studentRepo.Update(student);

            try
            {
                studentRepo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        [Route()]
        [ResponseType(typeof(StudentDTO))]
        public IHttpActionResult PostStudent(string studentID ,string firstName, string lastName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(studentID == null || firstName == null || lastName == null)
            {
                return BadRequest("One or more parameters are missing values");
            }

            Student student = new Student { StudentID = studentID, FirstName = firstName, LastName = lastName };

            
            studentRepo.Add(student);
            studentRepo.Save();

            try
            {
                studentRepo.Save();
                return Ok(student);
            }
            catch
            {
                return BadRequest("Failed to add student");
            }

            //return CreatedAtRoute("DefaultApi", new { id = Student.ID }, Student);
        }

        [Route("{id}")]
        [ResponseType(typeof(StudentDTO))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = studentRepo.Get(id);
            if (student == null)
            {
                return NotFound();
            }

            studentRepo.Remove(student);
            studentRepo.Save();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                studentRepo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return studentRepo.Exists(id) > 0;
        }
    }
}