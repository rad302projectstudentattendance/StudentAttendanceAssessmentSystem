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
    [RoutePrefix("Api/StudentGrades")]
    public class StudentGradesController : ApiController
    {

        private IStudentGradeRepository studentGradeRepo;

        public StudentGradesController()
        {
            studentGradeRepo = new StudentGradeRespository();
        }


        public IEnumerable<StudentGradeDTO> GetStudentGrades()
        {

            var StudentGrades = studentGradeRepo.FindAll();
            List<StudentGradeDTO> StudentGradeDTOs = new List<StudentGradeDTO>();
            Mapper.Initialize(c => c.CreateMap<DbSet<StudentGrade>, List<StudentGradeDTO>>());
            StudentGradeDTOs = Mapper.Map<List<StudentGradeDTO>>(StudentGrades);

            return StudentGradeDTOs;
        }

        [Route("StudentGrade/{id}")]  // GET: Api/StudentGrades/5
        [ResponseType(typeof(StudentGradeDTO))]
        public IHttpActionResult GetStudentGrade(int id)
        {
            StudentGrade StudentGrade = (StudentGrade)studentGradeRepo.Find(id);
            if (StudentGrade == null)
            {
                return NotFound();
            }

            Mapper.Initialize(c => c.CreateMap<StudentGrade, StudentGradeDTO>());

            StudentGradeDTO StudentGradeDTO = Mapper.Map<StudentGradeDTO>(StudentGrade);
            return Ok(StudentGradeDTO);
        }



        // PUT: Api/StudentGrades/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudentGrade(int id, StudentGradeDTO StudentGradeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != StudentGradeDTO.ID)
            {
                return BadRequest();
            }

            Mapper.Initialize(c => c.CreateMap<StudentGradeDTO, StudentGrade>());

            StudentGrade StudentGrade = Mapper.Map<StudentGrade>(StudentGradeDTO);
            studentGradeRepo.Update(StudentGrade);

            try
            {
                studentGradeRepo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentGradeExists(id))
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
        [ResponseType(typeof(StudentGradeDTO))]
        public IHttpActionResult PostStudentGrade(StudentGradeDTO StudentGradeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mapper.Initialize(c => c.CreateMap<StudentGradeDTO, StudentGrade>());

            StudentGrade StudentGrade = Mapper.Map<StudentGrade>(StudentGradeDTO);
            studentGradeRepo.Add(StudentGrade);
            studentGradeRepo.Save();

            return CreatedAtRoute("DefaultApi", new { id = StudentGrade.ID }, StudentGrade);
        }

        [Route("{id}")]
        [ResponseType(typeof(StudentGradeDTO))]
        public IHttpActionResult DeleteStudentGrade(int id)
        {
            StudentGrade StudentGrade = (StudentGrade)studentGradeRepo.Find(id);
            if (StudentGrade == null)
            {
                return NotFound();
            }

            studentGradeRepo.Remove(StudentGrade);
            studentGradeRepo.Save();

            return Ok(StudentGrade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                studentGradeRepo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentGradeExists(int id)
        {
            return studentGradeRepo.Exists(id) > 0;
        }
    }
}