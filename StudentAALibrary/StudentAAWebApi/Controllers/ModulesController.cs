using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using StudentAALibrary;
using StudentAAWebApi.Models.DTO;

namespace StudentAAWebApi.Controllers
{
    [RoutePrefix("Api/Modules")]
    public class ModulesController : ApiController
    {
        private StudentAAContext db = new StudentAAContext();

   
        [Route()]
        public IQueryable<ModuleDTO> GetModules()
        {
            var modules = db.Modules;
            List<ModuleDTO> moduleDTOs = new List<ModuleDTO>();
            Mapper.Initialize(c => c.CreateMap<DbSet<Module>, List<ModuleDTO>>());
            moduleDTOs = Mapper.Map<List<ModuleDTO>>(modules);

            return (IQueryable<ModuleDTO>) moduleDTOs;
        }

        [Route("Module/{id}")]  // GET: Api/Modules/5
        [ResponseType(typeof(ModuleDTO))]
        public IHttpActionResult GetModule(int id)
        {
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return NotFound();
            }

            Mapper.Initialize(c => c.CreateMap<Module, ModuleDTO>());

            ModuleDTO moduleDTO = Mapper.Map<ModuleDTO>(module);
            return Ok(moduleDTO);
        }



        // PUT: Api/Modules/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutModule(int id, ModuleDTO moduleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != moduleDTO.ID)
            {
                return BadRequest();
            }

            Mapper.Initialize(c => c.CreateMap<ModuleDTO, Module>());

            Module module = Mapper.Map<Module>(moduleDTO);
            db.Entry(module).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

       
        [Route()]
        [ResponseType(typeof(ModuleDTO))]
        public IHttpActionResult PostModule(ModuleDTO moduleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mapper.Initialize(c => c.CreateMap<ModuleDTO, Module>());

            Module module = Mapper.Map<Module>(moduleDTO);
            db.Modules.Add(module);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = module.ID }, module);
        }

        [Route("{id}")]
        [ResponseType(typeof(ModuleDTO))]
        public IHttpActionResult DeleteModule(int id)
        {
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return NotFound();
            }

            db.Modules.Remove(module);
            db.SaveChanges();

            return Ok(module);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModuleExists(int id)
        {
            return db.Modules.Count(e => e.ID == id) > 0;
        }
    }
}