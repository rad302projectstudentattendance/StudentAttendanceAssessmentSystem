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
using StudentAAWebApi.DAL;

namespace StudentAAWebApi.Controllers
{
    [RoutePrefix("Api/Modules")]
    public class ModulesController : ApiController
    {
        private IModuleRepository moduleRepo;

        public ModulesController()
        {
            moduleRepo = new ModuleRepository(new StudentAAContext());
        }
   
        [Route()]
        public IQueryable<ModuleDTO> GetModules()
        {
            var modules = moduleRepo.GetModules();
            List<ModuleDTO> moduleDTOs = new List<ModuleDTO>();
            Mapper.Initialize(c => c.CreateMap<DbSet<Module>, List<ModuleDTO>>());
            moduleDTOs = Mapper.Map<List<ModuleDTO>>(modules);

            return (IQueryable<ModuleDTO>) moduleDTOs;
        }

        [Route("Module/{id}")]  // GET: Api/Modules/5
        [ResponseType(typeof(ModuleDTO))]
        public IHttpActionResult GetModule(int id)
        {
            Module module = moduleRepo.GetModuleByID(id);
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
            moduleRepo.UpdateModule(module);

            try
            {
                moduleRepo.Save();
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
            moduleRepo.InsertModule(module);
            moduleRepo.Save();

            return CreatedAtRoute("DefaultApi", new { id = module.ID }, module);
        }

        [Route("{id}")]
        [ResponseType(typeof(ModuleDTO))]
        public IHttpActionResult DeleteModule(int id)
        {
            Module module = moduleRepo.GetModuleByID(id);
            if (module == null)
            {
                return NotFound();
            }

            moduleRepo.DeleteModule(module);
            moduleRepo.Save();

            return Ok(module);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                moduleRepo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModuleExists(int id)
        {
            return moduleRepo.Exists(id) > 0;
        }
    }
}