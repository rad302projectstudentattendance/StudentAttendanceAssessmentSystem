using StudentAALibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace StudentAAWebApi.DAL
{
    public class AttendanceRepository : IAttendanceRepository
    {

        private StudentAAContext context;

        public AttendanceRepository()
        {
            context = new StudentAAContext();
        }

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

        public IEnumerable<Attendance> GetAll()
        {
            return context.Attendances;
        }

        public Attendance Get(int id)
        {
            return context.Attendances.FirstOrDefault(c => c.ID == id);
        }
    }
}