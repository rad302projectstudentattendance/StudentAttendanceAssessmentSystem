using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAAWebApi.Models.DTO;

namespace StudentAAWebApi.DAL
{
    interface ILecturerRepository: IDisposable
    {
        IEnumerable<LecturerDTO> GetLecturers();
        LecturerDTO GetLecturerByID(int LecturerID);
    }
}
