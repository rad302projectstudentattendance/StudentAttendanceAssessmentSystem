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
        public IHttpActionResult PutStudent(int id, StudentDTO StudentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != StudentDTO.ID)
            {
                return BadRequest();
            }



            Student Student = Mapper.Map<Student>(StudentDTO);
            studentRepo.Update(Student);

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
        public IHttpActionResult PostStudent(StudentDTO StudentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            Student Student = Mapper.Map<Student>(StudentDTO);
            studentRepo.Add(Student);
            studentRepo.Save();

            return CreatedAtRoute("DefaultApi", new { id = Student.ID }, Student);
        }

        [Route("{id}")]
        [ResponseType(typeof(StudentDTO))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student Student = studentRepo.Get(id);
            if (Student == null)
            {
                return NotFound();
            }

            studentRepo.Remove(Student);
            studentRepo.Save();

            return Ok(Student);
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