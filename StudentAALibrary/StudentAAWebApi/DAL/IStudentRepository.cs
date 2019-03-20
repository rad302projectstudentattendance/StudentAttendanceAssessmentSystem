using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentAAWebApi.Models.DTO;

namespace StudentAAWebApi.DAL
{
    interface IStudentRepository: IDisposable
    {
        IEnumerable<StudentDTO> GetStudents();
        StudentDTO GetStudentByID(int studentID);

    }
}