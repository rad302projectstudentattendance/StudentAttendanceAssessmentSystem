using StudentAALibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace StudentAAWebApi.DAL
{
    public class StudentRepository : IStudentRepository
    {

        private StudentAAContext context;
        public StudentRepository()
        {
            context = new StudentAAContext();
        }

        public void Add(Student entity)
        {
            if (entity != null)
                context.Students.Add(entity);
        }

        public Student Get(int id)
        {
            return context.Students.FirstOrDefault(c=> c.ID == id);
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

        public IEnumerable<Student> GetAll()
        {
            return context.Students;
        }
    }
}