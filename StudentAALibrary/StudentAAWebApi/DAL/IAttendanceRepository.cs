using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAALibrary;

namespace StudentAAWebApi.DAL
{
    interface IAttendanceRepository: IDisposable
    {
        IEnumerable<Attendance> GetAttendances();
        Attendance GetAttendanceByID(int attendanceID);
    }
}
