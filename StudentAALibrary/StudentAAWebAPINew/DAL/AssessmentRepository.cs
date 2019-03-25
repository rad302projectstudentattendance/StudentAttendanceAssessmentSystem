using StudentAALibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace StudentAAWebApi.DAL
{
    public class AssessmentRepository : IAssessmentRepository
    {
        private StudentAAContext context;
        public AssessmentRepository()
        {
            context = new StudentAAContext();
        }
        public void Add(Assessment entity)
        {

            if (entity != null)
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

        public IEnumerable<Assessment> GetAll()
        {
            return context.Assessments;
        }

        public Assessment Get(int id)
        {
            return context.Assessments.FirstOrDefault(c => c.ID == id);
        }
    }
}