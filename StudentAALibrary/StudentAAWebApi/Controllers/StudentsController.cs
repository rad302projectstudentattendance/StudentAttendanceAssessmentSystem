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

namespace StudentAAWebApi.Controllers
{
    [RoutePrefix("Api/Students")]
    public class StudentsController : ApiController
    {
        private IStudentRepository studentRepo;

        public StudentsController()
        {
            studentRepo = new StudentRespository();
        }

        
        public IEnumerable<StudentDTO> GetStudents()
        {

            var students = studentRepo.FindAll();
            List<StudentDTO> studentDTOs = new List<StudentDTO>();
            Mapper.Initialize(c => c.CreateMap<DbSet<Student>, List<StudentDTO>>());
            studentDTOs = Mapper.Map<List<StudentDTO>>(students);

            return studentDTOs;
        }

        [Route("Student/{id}")]  
        [ResponseType(typeof(StudentDTO))]
        public IHttpActionResult GetStudent(int id)
        {
            Student student = (Student)studentRepo.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            Mapper.Initialize(c => c.CreateMap<Student, StudentDTO>());

            StudentDTO studentDTO = Mapper.Map<StudentDTO>(student);
            return Ok(studentDTO);
        }



       
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, StudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentDTO.ID)
            {
                return BadRequest();
            }

            Mapper.Initialize(c => c.CreateMap<StudentDTO, Student>());

            Student student = Mapper.Map<Student>(studentDTO);
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
        public IHttpActionResult PostStudent(StudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mapper.Initialize(c => c.CreateMap<StudentDTO, Student>());

            Student student = Mapper.Map<Student>(studentDTO);
            studentRepo.Add(student);
            studentRepo.Save();

            return CreatedAtRoute("DefaultApi", new { id = student.ID }, student);
        }

        [Route("{id}")]
        [ResponseType(typeof(StudentDTO))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = (Student)studentRepo.Find(id);
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