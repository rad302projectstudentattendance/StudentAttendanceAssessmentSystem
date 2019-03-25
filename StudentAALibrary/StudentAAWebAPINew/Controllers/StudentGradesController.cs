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
    [RoutePrefix("api/StudentGrades")]
    public class StudentGradesController : ApiController
    {
        private IStudentGradeRepository StudentGradeRepo;

        public StudentGradesController()
        {
            StudentGradeRepo = new StudentGradeRepository();
        }

        [Route()]
        public IEnumerable<StudentGradeDTO> GetStudentGrades()
        {

            var StudentGrades = StudentGradeRepo.GetAll();
            List<StudentGradeDTO> StudentGradeDTOs = new List<StudentGradeDTO>();
            foreach (var StudentGrade in StudentGrades)
            {
                StudentGradeDTOs.Add(Mapper.Map<StudentGradeDTO>(StudentGrade));
            }


            return StudentGradeDTOs;
        }

        [Route("StudentGrade/{id}")]  // GET: Api/StudentGrades/5
        [ResponseType(typeof(StudentGradeDTO))]
        public IHttpActionResult GetStudentGrade(int id)
        {
            StudentGrade StudentGrade = StudentGradeRepo.Get(id);
            if (StudentGrade == null)
            {
                return NotFound();
            }



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



            StudentGrade StudentGrade = Mapper.Map<StudentGrade>(StudentGradeDTO);
            StudentGradeRepo.Update(StudentGrade);

            try
            {
                StudentGradeRepo.Save();
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


            StudentGrade StudentGrade = Mapper.Map<StudentGrade>(StudentGradeDTO);
            StudentGradeRepo.Add(StudentGrade);
            StudentGradeRepo.Save();

            return CreatedAtRoute("DefaultApi", new { id = StudentGrade.ID }, StudentGrade);
        }

        [Route("{id}")]
        [ResponseType(typeof(StudentGradeDTO))]
        public IHttpActionResult DeleteStudentGrade(int id)
        {
            StudentGrade StudentGrade = StudentGradeRepo.Get(id);
            if (StudentGrade == null)
            {
                return NotFound();
            }

            StudentGradeRepo.Remove(StudentGrade);
            StudentGradeRepo.Save();

            return Ok(StudentGrade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                StudentGradeRepo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentGradeExists(int id)
        {
            return StudentGradeRepo.Exists(id) > 0;
        }
    }
}