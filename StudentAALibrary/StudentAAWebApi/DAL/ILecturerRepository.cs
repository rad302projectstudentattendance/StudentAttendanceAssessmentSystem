using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAALibrary;

namespace StudentAAWebApi.DAL
{
    interface ILecturerRepository: IDisposable
    {
        IEnumerable<Lecturer> GetLecturers();
        Lecturer GetLecturerByID(int lecturerID);
    }
}
