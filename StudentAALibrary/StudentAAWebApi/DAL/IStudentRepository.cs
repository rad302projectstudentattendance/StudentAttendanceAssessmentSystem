using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentAALibrary;

namespace StudentAAWebApi.DAL
{
    interface IStudentRepository: IDisposable
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentByID(int studentID);

    }
}