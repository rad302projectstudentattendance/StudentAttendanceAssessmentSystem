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
    [RoutePrefix("Api/Lecturers")]
    public class LecturersController : ApiController
    {
        private ILecturerRepository lecturerRepo;

        public LecturersController()
        {
            lecturerRepo = new LecturerRepository();
        }

        [Route()]
        public IEnumerable<LecturerDTO> GetLecturers()
        {

            var Lecturers = lecturerRepo.FindAll();
            List<LecturerDTO> LecturerDTOs = new List<LecturerDTO>();
            Mapper.Initialize(c => c.CreateMap<DbSet<Lecturer>, List<LecturerDTO>>());
            LecturerDTOs = Mapper.Map<List<LecturerDTO>>(Lecturers);

            return LecturerDTOs;
        }

        [Route("Lecturer/{id}")]  // GET: Api/Lecturers/5
        [ResponseType(typeof(LecturerDTO))]
        public IHttpActionResult GetLecturer(int id)
        {
            Lecturer Lecturer = (Lecturer)lecturerRepo.Find(id);
            if (Lecturer == null)
            {
                return NotFound();
            }

            Mapper.Initialize(c => c.CreateMap<Lecturer, LecturerDTO>());

            LecturerDTO LecturerDTO = Mapper.Map<LecturerDTO>(Lecturer);
            return Ok(LecturerDTO);
        }



        // PUT: Api/Lecturers/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLecturer(int id, LecturerDTO LecturerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != LecturerDTO.ID)
            {
                return BadRequest();
            }

            Mapper.Initialize(c => c.CreateMap<LecturerDTO, Lecturer>());

            Lecturer Lecturer = Mapper.Map<Lecturer>(LecturerDTO);
            lecturerRepo.Update(Lecturer);

            try
            {
                lecturerRepo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LecturerExists(id))
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
        [ResponseType(typeof(LecturerDTO))]
        public IHttpActionResult PostLecturer(LecturerDTO LecturerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mapper.Initialize(c => c.CreateMap<LecturerDTO, Lecturer>());

            Lecturer Lecturer = Mapper.Map<Lecturer>(LecturerDTO);
            lecturerRepo.Add(Lecturer);
            lecturerRepo.Save();

            return CreatedAtRoute("DefaultApi", new { id = Lecturer.ID }, Lecturer);
        }

        [Route("{id}")]
        [ResponseType(typeof(LecturerDTO))]
        public IHttpActionResult DeleteLecturer(int id)
        {
            Lecturer Lecturer = (Lecturer)lecturerRepo.Find(id);
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