using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAALibrary;

namespace StudentAAWebApi.DAL
{
    interface IStudentGradeRepository: IDisposable
    {
        IEnumerable<StudentGrade> GetStudentGrades();
        StudentGrade GetStudentGradeByID(int studentGradeID);
    }
}
