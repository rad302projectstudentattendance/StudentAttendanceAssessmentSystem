using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentAAWebApi.Models.DTO;

namespace StudentAAWebApi.DAL
{
    public class AssessmentRepository : IAssessmentRepository, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public AssessmentDTO GetAssessmentByID(int assessmentID)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<AssessmentDTO> GetAssessments()
        {
            throw new NotImplementedException();
        }
    }

    public class AttendanceRepository : IAttendanceRepository, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public AttendanceDTO GetAttendanceByID(int attendanceID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AttendanceDTO> GetAttendances()
        {
            throw new NotImplementedException();
        }
    }

    public class LecturerRepository : ILecturerRepository, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public LecturerDTO GetLecturerByID(int lecturerID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LecturerDTO> GetLecturers()
        {
            throw new NotImplementedException();
        }
    }

    public class ModuleRepository : IModuleRepository, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ModuleDTO GetModuleByID(int moduleID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ModuleDTO> GetModules()
        {
            throw new NotImplementedException();
        }
    }

    public class StudentGradeRepository : IStudentGradeRepository, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public StudentGradeDTO GetStudentGradeByID(int studentGradeID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentGradeDTO> GetStudentGrades()
        {
            throw new NotImplementedException();
        }
    }

    public class StudentRepository : IStudentRepository, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public StudentDTO GetStudentByID(int studentID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentDTO> GetStudents()
        {
            throw new NotImplementedException();
        }
    }
}