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
    [RoutePrefix("api/Assessments")]
    public class AssessmentsController : ApiController
    {
        private IAssessmentRepository AssessmentRepo;

        public AssessmentsController()
        {
            AssessmentRepo = new AssessmentRepository();
        }

        [Route()]
        public IEnumerable<AssessmentDTO> GetAssessments()
        {

            var Assessments = AssessmentRepo.GetAll();
            List<AssessmentDTO> AssessmentDTOs = new List<AssessmentDTO>();
            foreach (var Assessment in Assessments)
            {
                AssessmentDTOs.Add(Mapper.Map<AssessmentDTO>(Assessment));
            }


            return AssessmentDTOs;
        }

        [Route("Assessment/{id}")]  // GET: Api/Assessments/5
        [ResponseType(typeof(AssessmentDTO))]
        public IHttpActionResult GetAssessment(int id)
        {
            Assessment Assessment = AssessmentRepo.Get(id);
            if (Assessment == null)
            {
                return NotFound();
            }



            AssessmentDTO AssessmentDTO = Mapper.Map<AssessmentDTO>(Assessment);
            return Ok(AssessmentDTO);
        }



        // PUT: Api/Assessments/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssessment(int id, string assessmentName, string summary, float maxGrade )
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var assessment = AssessmentRepo.Get(id);
            if (assessment == null)
                return BadRequest();

            if (assessmentName != null)
            {
                assessment.AssessmentName = assessmentName;
            }
            if (summary != null)
                assessment.Summary = summary;

            if (maxGrade >0)
                assessment.MaxGrade = maxGrade;

            


            
            AssessmentRepo.Update(assessment);

            try
            {
                AssessmentRepo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentExists(id))
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
        [ResponseType(typeof(AssessmentDTO))]
        public IHttpActionResult PostAssessment(string assessmentName, string summary, float maxGrade, int moduleID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (assessmentName == null || summary == null || maxGrade <= 0 || moduleID <= 0)
                return BadRequest("One or more parameters are missing values");



            Assessment assessment = new Assessment { AssessmentName = assessmentName, Summary = summary, MaxGrade = maxGrade, ModuleID = moduleID };
            AssessmentRepo.Add(assessment);
            try
            {
                AssessmentRepo.Save();
                return Ok(assessment);
            }
            catch
            {
                return BadRequest("Failed to add assessment");
            }
        }

        [Route("{id}")]
        [ResponseType(typeof(AssessmentDTO))]
        public IHttpActionResult DeleteAssessment(int id)
        {
            Assessment Assessment = AssessmentRepo.Get(id);
            if (Assessment == null)
            {
                return NotFound();
            }

            AssessmentRepo.Remove(Assessment);
            AssessmentRepo.Save();

            return Ok(Assessment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                AssessmentRepo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssessmentExists(int id)
        {
            return AssessmentRepo.Exists(id) > 0;
        }
    }
}