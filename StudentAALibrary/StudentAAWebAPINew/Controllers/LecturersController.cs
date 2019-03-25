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
{   [Authorize]
    [RoutePrefix("api/Lecturers")]
    public class LecturersController : ApiController
    {
        private ILecturerRepository lecturerRepo;

        public LecturersController()
        {
            lecturerRepo = new LecturerRepository();
        }

        /// <summary>
        /// Gets all Lecturer data
        /// </summary>
        [Route()]
        public IEnumerable<LecturerDTO> GetLecturers()
        {

            var lecturers = lecturerRepo.GetAll();
            List<LecturerDTO> LecturerDTOs = new List<LecturerDTO>();
            foreach (var lecturer in lecturers)
            {
                LecturerDTOs.Add(Mapper.Map<LecturerDTO>(lecturer));
            }
            

            return LecturerDTOs;
        }

        /// <summary>
        /// Get Lecturer data
        /// </summary>
        [Route("Lecturer/{id}")]  // GET: Api/Lecturers/5
        [ResponseType(typeof(LecturerDTO))]
        public IHttpActionResult GetLecturer(int id)
        {
            Lecturer Lecturer = lecturerRepo.Get(id);
            if (Lecturer == null)
            {
                return NotFound();
            }

            

            LecturerDTO LecturerDTO = Mapper.Map<LecturerDTO>(Lecturer);
            return Ok(LecturerDTO);
        }


        /// <summary>
        /// Edit Lecturer Data
        /// </summary>
        // PUT: Api/Lecturers/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLecturer(LecturerDTO lecturerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var lecturer = lecturerRepo.Get(id);

            //if (lecturer == null)
            //    return BadRequest("Invalid parameters");

            //lecturer.FirstName = firstName;
            //lecturer.LastName = lastName;

            Lecturer lecturer = Mapper.Map<Lecturer>(lecturerDTO); 
            lecturerRepo.Update(lecturer);

            try
            {
                lecturerRepo.Save();
                return Ok(lecturer);
            }
            catch (DbUpdateConcurrencyException)
            {
               
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        /// <summary>
        /// Create Lecturer data
        /// </summary>
        [Route()]
        [ResponseType(typeof(LecturerDTO))]
        public IHttpActionResult PostLecturer(LecturerDTO lecturerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Lecturer lecturer = Mapper.Map<Lecturer>(lecturerDTO);
    
            lecturerRepo.Add(lecturer);
           
            try
            {
                lecturerRepo.Save();
                return Ok(lecturer);
            }
            catch
            {
                return BadRequest("Failed to add Lecturer");
            }
            
            //return CreatedAtRoute("DefaultApi", new { id = Lecturer.ID }, Lecturer);
            //return Ok(lecturer);
        }

        /// <summary>
        /// Delete Lecturer data
        /// </summary>
        [Route("{id}")]
        [ResponseType(typeof(LecturerDTO))]
        public IHttpActionResult DeleteLecturer(int id)
        {
            Lecturer Lecturer = lecturerRepo.Get(id);
            if (Lecturer == null)
            {
                return NotFound();
            }

            lecturerRepo.Remove(Lecturer);
            lecturerRepo.Save();

            return Ok(Lecturer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                lecturerRepo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LecturerExists(int id)
        {
            return lecturerRepo.Exists(id) > 0;
        }
    }
}