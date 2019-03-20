using StudentAALibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentAAWebApi.DAL
{
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
            throw new NotImplementedException();
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

       
    }
}