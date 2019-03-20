using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAAWebApi.Models.DTO;

namespace StudentAAWebApi.DAL
{
    interface IAttendanceRepository
    {
        IEnumerable<AttendanceDTO> GetAttendances();
        AttendanceDTO GetAttendanceByID(int attendanceID);
    }
}
