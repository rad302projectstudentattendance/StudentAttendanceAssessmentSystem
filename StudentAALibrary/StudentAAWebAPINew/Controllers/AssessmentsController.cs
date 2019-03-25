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



            Assessment Assessment = Mapper.Map<Assessment>(AssessmentDTO);
            AssessmentRepo.Update(Assessment);

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
        public IHttpActionResult PostAssessment(AssessmentDTO AssessmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            Assessment Assessment = Mapper.Map<Assessment>(AssessmentDTO);
            AssessmentRepo.Add(Assessment);
            AssessmentRepo.Save();

            return CreatedAtRoute("DefaultApi", new { id = Assessment.ID }, Assessment);
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