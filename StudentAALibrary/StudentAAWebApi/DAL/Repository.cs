using StudentAALibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace StudentAAWebApi.DAL
{
    public class AssessmentRepository : IAssessmentRepository
    {
        private StudentAAContext context;

        public void Add(Assessment entity)
        {
            if(entity != null)
                context.Assessments.Add(entity);
        }

        public IQueryable<Assessment> Find(int id)
        {
            return (IQueryable<Assessment>)context.Assessments.Find(id);
        }

        public IQueryable<Assessment> FindAll()
        {
            return context.Assessments;
        }

        public void Remove(Assessment entity)
        {
            if (entity != null)
            context.Assessments.Remove(entity);
        }

        public void Update(Assessment entity)
        {
            if (entity != null)
                context.Assessments.AddOrUpdate(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Exists(int id)
        {
            return context.Assessments.Count(e => e.ID == id);
        }
    }

    public class AttendanceRepository: IAttendanceRepository
    {
        private StudentAAContext context;

        public void Add(Attendance entity)
        {
            if (entity != null)
                context.Attendances.Add(entity);
        }

        public IQueryable<Attendance> Find(int id)
        {
            return (IQueryable<Attendance>)context.Attendances.Find(id);
        }

        public IQueryable<Attendance> FindAll()
        {
            return context.Attendances;
        }

        public void Remove(Attendance entity)
        {
            if (entity != null)
                context.Attendances.Remove(entity);
        }

        public void Update(Attendance entity)
        {
            if (entity != null)
                context.Attendances.AddOrUpdate(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Exists(int id)
        {
            return context.Attendances.Count(e => e.ID == id);
        }
    }

    public class LecturerRepository: ILecturerRepository
    {
        private StudentAAContext context;

        public void Add(Lecturer entity)
        {
            if (entity != null)
                context.Lecturers.Add(entity);
        }

        public IQueryable<Lecturer> Find(int id)
        {
            return (IQueryable<Lecturer>)context.Lecturers.Find(id);
        }


        public IQueryable<Lecturer> FindAll()
        {
            return context.Lecturers;
        }

        public void Remove(Lecturer entity)
        {
            if (entity != null)
                context.Lecturers.Remove(entity);
        }

        public void Update(Lecturer entity)
        {
            if (entity != null)
                context.Lecturers.AddOrUpdate(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Exists(int id)
        {
            return context.Lecturers.Count(e => e.ID == id);
        }
    }

    public class ModuleRepository: IModuleRepository
    {
        private StudentAAContext context;

        public void Add(Module entity)
        {
            if (entity != null)
                context.Modules.Add(entity);
        }

        public IQueryable<Module> Find(int id)
        {
            return (IQueryable<Module>)context.Modules.Find(id);
        }


        public IQueryable<Module> FindAll()
        {
            return context.Modules;
        }

        public void Remove(Module entity)
        {
            if (entity != null)
                context.Modules.Remove(entity);
        }

        public void Update(Module entity)
        {
            if (entity != null)
                context.Modules.AddOrUpdate(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Exists(int id)
        {
            return context.Modules.Count(e => e.ID == id);
        }
    }

    public class StudentGradeRepository: IStudentGradeRepository
    {
        private StudentAAContext context;

        public void Add(StudentGrade entity)
        {
            if (entity != null)
                context.StudentGrades.Add(entity);
        }

        public IQueryable<StudentGrade> Find(int id)
        {
            return (IQueryable<StudentGrade>)context.StudentGrades.Find(id);
        }


        public IQueryable<StudentGrade> FindAll()
        {
            return context.StudentGrades;
        }

        public void Remove(StudentGrade entity)
        {
            if (entity != null)
                context.StudentGrades.Remove(entity);
        }

        public void Update(StudentGrade entity)
        {
            if (entity != null)
                context.StudentGrades.AddOrUpdate(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Exists(int id)
        {
            return context.StudentGrades.Count(e => e.ID == id);
        }
    }

    public class StudentRespository : IStudentRepository
    {

        private StudentAAContext context;

        public void Add(Student entity)
        {
            if (entity != null)
                context.Students.Add(entity);
        }

        public IQueryable<Student> Find(int id)
        {
            return (IQueryable<Student>)context.Students.Find(id);
        }


        public IQueryable<Student> FindAll()
        {
            return context.Students;
        }

        public void Remove(Student entity)
        {
            if (entity != null)
                context.Students.Remove(entity);
        }

        public void Update(Student entity)
        {
            if (entity != null)
                context.Students.AddOrUpdate(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Exists(int id)
        {
            return context.Students.Count(e => e.ID == id);
        }
    }

}