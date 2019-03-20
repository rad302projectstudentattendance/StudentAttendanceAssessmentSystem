using StudentAALibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace StudentAAWebApi.DAL
{
    public class AssessmentRepository : IAssessmentRepository, IDisposable
    {
        StudentAAContext context;

        public AssessmentRepository(StudentAAContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Assessment GetAssessmentByID(int assessmentID)
        {
            return context.Assessments.Find(assessmentID);
        }

        public IEnumerable<Assessment> GetAssessments()
        {
            return context.Assessments.ToList();
        }
    }

    public class AttendanceRepository : IAttendanceRepository, IDisposable
    {
        StudentAAContext context;

        public AttendanceRepository(StudentAAContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Attendance GetAttendanceByID(int attendanceID)
        {
            return context.Attendances.Find(attendanceID);
        }

        public IEnumerable<Attendance> GetAttendances()
        {
            return context.Attendances.ToList();
        }
    }

    public class LecturerRepository : ILecturerRepository, IDisposable
    {
        StudentAAContext context;

        public LecturerRepository(StudentAAContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Lecturer GetLecturerByID(int lecturerID)
        {
            return context.Lecturers.Find(lecturerID);
        }

        public IEnumerable<Lecturer> GetLecturers()
        {
            return context.Lecturers.ToList();
        }
    }

    public class ModuleRepository : IModuleRepository, IDisposable
    {
        StudentAAContext context;

        public ModuleRepository(StudentAAContext context)
        {
            this.context = context;
        }

        public void DeleteModule(Module module)
        {
            context.Modules.Remove(module);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Module GetModuleByID(int moduleID)
        {
            return context.Modules.Find(moduleID);
        }

        public IEnumerable<Module> GetModules()
        {
            return context.Modules.ToList();
        }

        public void InsertModule(Module module)
        {
            context.Modules.Add(module);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateModule(Module module)
        {
            context.Modules.AddOrUpdate(module);
        }

        public int Exists(int moduleID)
        {
            return context.Modules.Count(e => e.ID == moduleID);
        }
    }

    public class StudentGradeRepository : IStudentGradeRepository, IDisposable
    {
        StudentAAContext context;

        public StudentGradeRepository(StudentAAContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public StudentGrade GetStudentGradeByID(int studentGradeID)
        {
            return context.StudentGrades.Find(studentGradeID);
        }

        public IEnumerable<StudentGrade> GetStudentGrades()
        {
            return context.StudentGrades.ToList();
        }
    }

    public class StudentRepository : IStudentRepository, IDisposable
    {
        StudentAAContext context;

        public StudentRepository(StudentAAContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Student GetStudentByID(int studentID)
        {
            return context.Students.Find(studentID);
        }

        public IEnumerable<Student> GetStudents()
        {
            return context.Students.ToList();
        }
    }
}