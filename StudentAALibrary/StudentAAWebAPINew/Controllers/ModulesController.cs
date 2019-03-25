using AutoMapper;
using StudentAALibrary;
using StudentAAWebApi.DAL;
using StudentAAWebApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace StudentAAWebApi.Controllers
{
    [RoutePrefix("api/Modules")]
    public class ModulesController : ApiController
    {
        private IModuleRepository ModuleRepo;

        public ModulesController()
        {
            ModuleRepo = new ModuleRepository();
        }

        [Route()]
        public IEnumerable<ModuleDTO> GetModules()
        {

            var Modules = ModuleRepo.GetAll();
            List<ModuleDTO> ModuleDTOs = new List<ModuleDTO>();
            foreach (var Module in Modules)
            {
                ModuleDTOs.Add(Mapper.Map<ModuleDTO>(Module));
            }


            return ModuleDTOs;
        }

        [Route("Module/{id}")]  // GET: Api/Modules/5
        [ResponseType(typeof(ModuleDTO))]
        public IHttpActionResult GetModule(int id)
        {
            Module Module = ModuleRepo.Get(id);
            if (Module == null)
            {
                return NotFound();
            }



            ModuleDTO ModuleDTO = Mapper.Map<ModuleDTO>(Module);
            return Ok(ModuleDTO);
        }



        // PUT: Api/Modules/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutModule(int id, string moduleName)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Module module = ModuleRepo.Get(id);
            if (module == null)
            {
                return BadRequest();
            }

            module.ModuleName = moduleName;

           
            ModuleRepo.Update(module);

            try
            {
                ModuleRepo.Save();
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
        public IHttpActionResult PostModule(string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (name == null)
                return BadRequest("One or more parameters missing values");

            Module module = new Module { ModuleName = name };
            ModuleRepo.Add(module);

            try
            {
                ModuleRepo.Save();
                return Ok(module);
            }
            catch
            {
                return BadRequest("Failed to add module");
            }

        }

        [Route("{id}")]
        [ResponseType(typeof(ModuleDTO))]
        public IHttpActionResult DeleteModule(int id)
        {
            Module Module = ModuleRepo.Get(id);
            if (Module == null)
            {
                return NotFound();
            }

            ModuleRepo.Remove(Module);
            ModuleRepo.Save();

            return Ok(Module);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ModuleRepo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModuleExists(int id)
        {
            return ModuleRepo.Exists(id) > 0;
        }
    }
}