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
        public IHttpActionResult PutStudentGrade(int id, float grade)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            StudentGrade studentGrade = StudentGradeRepo.Get(id);
            if (studentGrade != null)
            {
                return BadRequest();
            }

            studentGrade.Grade = grade;


            
            StudentGradeRepo.Update(studentGrade);

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
        public IHttpActionResult PostStudentGrade(int studentID, float grade, int assessmentID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            StudentGrade studentGrade = new StudentGrade { StudentID = studentID, AssessmentID = assessmentID, Grade = grade } ;
            StudentGradeRepo.Add(studentGrade);

            try
            {
                StudentGradeRepo.Save();
                return Ok(studentGrade);
            }
            catch
            {
                return BadRequest("Failed to add student grade");
            }

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