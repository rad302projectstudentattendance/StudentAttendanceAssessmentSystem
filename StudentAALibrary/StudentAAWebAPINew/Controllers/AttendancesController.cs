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
    [RoutePrefix("api/Attendances")]
    public class AttendancesController : ApiController
    {
        private IAttendanceRepository AttendanceRepo;

        public AttendancesController()
        {
            AttendanceRepo = new AttendanceRepository();
        }

        [Route()]
        public IEnumerable<AttendanceDTO> GetAttendances()
        {

            var Attendances = AttendanceRepo.GetAll();
            List<AttendanceDTO> AttendanceDTOs = new List<AttendanceDTO>();
            foreach (var Attendance in Attendances)
            {
                AttendanceDTOs.Add(Mapper.Map<AttendanceDTO>(Attendance));
            }


            return AttendanceDTOs;
        }

        [Route("Attendance/{id}")]  // GET: Api/Attendances/5
        [ResponseType(typeof(AttendanceDTO))]
        public IHttpActionResult GetAttendance(int id)
        {
            Attendance Attendance = AttendanceRepo.Get(id);
            if (Attendance == null)
            {
                return NotFound();
            }



            AttendanceDTO AttendanceDTO = Mapper.Map<AttendanceDTO>(Attendance);
            return Ok(AttendanceDTO);
        }



        // PUT: Api/Attendances/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAttendance(int id, AttendanceDTO AttendanceDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != AttendanceDTO.ID)
            {
                return BadRequest();
            }



            Attendance Attendance = Mapper.Map<Attendance>(AttendanceDTO);
            AttendanceRepo.Update(Attendance);

            try
            {
                AttendanceRepo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceExists(id))
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
        [ResponseType(typeof(AttendanceDTO))]
        public IHttpActionResult PostAttendance(AttendanceDTO AttendanceDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            Attendance Attendance = Mapper.Map<Attendance>(AttendanceDTO);
            AttendanceRepo.Add(Attendance);
            AttendanceRepo.Save();

            return CreatedAtRoute("DefaultApi", new { id = Attendance.ID }, Attendance);
        }

        [Route("{id}")]
        [ResponseType(typeof(AttendanceDTO))]
        public IHttpActionResult DeleteAttendance(int id)
        {
            Attendance Attendance = AttendanceRepo.Get(id);
            if (Attendance == null)
            {
                return NotFound();
            }

            AttendanceRepo.Remove(Attendance);
            AttendanceRepo.Save();

            return Ok(Attendance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                AttendanceRepo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AttendanceExists(int id)
        {
            return AttendanceRepo.Exists(id) > 0;
        }
    }
}