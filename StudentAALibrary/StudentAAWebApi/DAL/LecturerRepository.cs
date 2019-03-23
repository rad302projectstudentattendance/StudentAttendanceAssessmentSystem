using StudentAALibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace StudentAAWebApi.DAL
{
    public class LecturerRepository : ILecturerRepository
    {
        private StudentAAContext context;
        public LecturerRepository()
        {
            context = new StudentAAContext();
        }
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
}