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
    [RoutePrefix("Api/Attendances")]
    public class AttendancesController: ApiController
    {
        private IAttendanceRepository attendanceRepo;

        public AttendancesController()
        {
            attendanceRepo = new AttendanceRespository();
        }

        
        public IEnumerable<AttendanceDTO> GetAttendances()
        {

            var attendances = attendanceRepo.FindAll();
            List<AttendanceDTO> attendanceDTOs = new List<AttendanceDTO>();
            Mapper.Initialize(c => c.CreateMap<DbSet<Attendance>, List<AttendanceDTO>>());
            attendanceDTOs = Mapper.Map<List<AttendanceDTO>>(attendances);

            return attendanceDTOs;
        }

        [Route("Attendance/{id}")]  // GET: Api/Attendances/5
        [ResponseType(typeof(AttendanceDTO))]
        public IHttpActionResult GetAttendance(int id)
        {
            Attendance Attendance = (Attendance)attendanceRepo.Find(id);
            if (Attendance == null)
            {
                return NotFound();
            }

            Mapper.Initialize(c => c.CreateMap<Attendance, AttendanceDTO>());

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

            Mapper.Initialize(c => c.CreateMap<AttendanceDTO, Attendance>());

            Attendance Attendance = Mapper.Map<Attendance>(AttendanceDTO);
            attendanceRepo.Update(Attendance);

            try
            {
                attendanceRepo.Save();
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

            Mapper.Initialize(c => c.CreateMap<AttendanceDTO, Attendance>());

            Attendance Attendance = Mapper.Map<Attendance>(AttendanceDTO);
            attendanceRepo.Add(Attendance);
            attendanceRepo.Save();

            return CreatedAtRoute("DefaultApi", new { id = Attendance.ID }, Attendance);
        }

        [Route("{id}")]
        [ResponseType(typeof(AttendanceDTO))]
        public IHttpActionResult DeleteAttendance(int id)
        {
            Attendance Attendance = (Attendance)attendanceRepo.Find(id);
            if (Attendance == null)
            {
                return NotFound();
            }

            attendanceRepo.Remove(Attendance);
            attendanceRepo.Save();

            return Ok(Attendance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                attendanceRepo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AttendanceExists(int id)
        {
            return attendanceRepo.Exists(id) > 0;
        }
    }
}