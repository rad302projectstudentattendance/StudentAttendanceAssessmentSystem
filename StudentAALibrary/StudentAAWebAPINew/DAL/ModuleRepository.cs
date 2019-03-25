using StudentAALibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace StudentAAWebApi.DAL
{
    public class ModuleRepository :IModuleRepository
    {

        private StudentAAContext context;
        public ModuleRepository()
        {
            context = new StudentAAContext();
        }
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

        public IEnumerable<Module> GetAll()
        {
            return context.Modules;
        }

        public Module Get(int id)
        {
            return context.Modules.FirstOrDefault(c => c.ID == id);
        }
    }
}