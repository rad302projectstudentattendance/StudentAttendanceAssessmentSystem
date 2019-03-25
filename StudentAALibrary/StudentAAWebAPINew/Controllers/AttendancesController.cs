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
        public IHttpActionResult PutAttendance(AttendanceDTO attendanceDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (attendanceDTO == null)
                return BadRequest("Missing values");
            //Attendance attendance = AttendanceRepo.Get(id);

            //if (date != null)
            //    attendance.AttendanceDate = date;
            //if(studentIDList.Count > 0)
            //    foreach (var studentID in collection)
            //    {
            //        if(attendance.Students.FirstOrDefault(c=> c.StudentID == studentID) != null)
            //            attendance.Students.Add()
            //    }

            //if(date != null)
            //    attendance

            //attendance.ModuleID = moduleID;

            Attendance attendance = Mapper.Map<Attendance>(attendanceDTO);
            AttendanceRepo.Update(attendance);
            AttendanceRepo.Save();
            

            return StatusCode(HttpStatusCode.NoContent);
        }


        [Route()]
        [ResponseType(typeof(AttendanceDTO))]
        public IHttpActionResult PostAttendance(AttendanceDTO attendanceDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //if (date == null || studentIDList == null || moduleID <= 0)
            //{
            //    return BadRequest("One or more parameters are missing values");
            //}

            //Attendance attendance = new Attendance { ModuleID = moduleID, AttendanceDate = date};
            Attendance attendance = Mapper.Map<Attendance>(attendanceDTO);

            AttendanceRepo.Add(attendance);
            

            try
            {
                AttendanceRepo.Save();
                return Ok(attendance);
            }
            catch
            {
                return BadRequest("Failed to add attendance");
            }
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