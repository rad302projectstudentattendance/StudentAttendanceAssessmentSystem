using StudentAALibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace StudentAAWebApi.DAL
{
    public class StudentGradeRepository : IStudentGradeRepository
    {
        private StudentAAContext context;
        public StudentGradeRepository()
        {
            context = new StudentAAContext();
        }
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

        public IEnumerable<StudentGrade> GetAll()
        {
            return context.StudentGrades;
        }

        public StudentGrade Get(int id)
        {
            return context.StudentGrades.FirstOrDefault(c => c.ID == id);
        }
    }
}