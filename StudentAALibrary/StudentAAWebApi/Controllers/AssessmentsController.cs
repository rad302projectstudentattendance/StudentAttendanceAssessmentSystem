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
    [RoutePrefix("Api/Assessments")]
    public class AssessmentsController : ApiController
    {

        private IAssessmentRepository assessmentRepo;

        public AssessmentsController()
        {
            assessmentRepo = new AssessmentRespository();
        }


        public IEnumerable<AssessmentDTO> GetAssessments()
        {

            var Assessments = assessmentRepo.FindAll();
            List<AssessmentDTO> AssessmentDTOs = new List<AssessmentDTO>();
            Mapper.Initialize(c => c.CreateMap<DbSet<Assessment>, List<AssessmentDTO>>());
            AssessmentDTOs = Mapper.Map<List<AssessmentDTO>>(Assessments);

            return AssessmentDTOs;
        }

        [Route("Assessment/{id}")]  // GET: Api/Assessments/5
        [ResponseType(typeof(AssessmentDTO))]
        public IHttpActionResult GetAssessment(int id)
        {
            Assessment Assessment = (Assessment)assessmentRepo.Find(id);
            if (Assessment == null)
            {
                return NotFound();
            }

            Mapper.Initialize(c => c.CreateMap<Assessment, AssessmentDTO>());

            AssessmentDTO AssessmentDTO = Mapper.Map<AssessmentDTO>(Assessment);
            return Ok(AssessmentDTO);
        }



        // PUT: Api/Assessments/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssessment(int id, AssessmentDTO AssessmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != AssessmentDTO.ID)
            {
                return BadRequest();
            }

            Mapper.Initialize(c => c.CreateMap<AssessmentDTO, Assessment>());

            Assessment Assessment = Mapper.Map<Assessment>(AssessmentDTO);
            assessmentRepo.Update(Assessment);

            try
            {
                assessmentRepo.Save();
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
        public IHttpActionResult PostAssessment(AssessmentDTO AssessmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mapper.Initialize(c => c.CreateMap<AssessmentDTO, Assessment>());

            Assessment Assessment = Mapper.Map<Assessment>(AssessmentDTO);
            assessmentRepo.Add(Assessment);
            assessmentRepo.Save();

            return CreatedAtRoute("DefaultApi", new { id = Assessment.ID }, Assessment);
        }

        [Route("{id}")]
        [ResponseType(typeof(AssessmentDTO))]
        public IHttpActionResult DeleteAssessment(int id)
        {
            Assessment Assessment = (Assessment)assessmentRepo.Find(id);
            if (Assessment == null)
            {
                return NotFound();
            }

            assessmentRepo.Remove(Assessment);
            assessmentRepo.Save();

            return Ok(Assessment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                assessmentRepo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssessmentExists(int id)
        {
            return assessmentRepo.Exists(id) > 0;
        }
    }
}