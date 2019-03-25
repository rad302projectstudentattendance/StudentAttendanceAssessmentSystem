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
        public IHttpActionResult PutModule(int id, ModuleDTO ModuleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ModuleDTO.ID)
            {
                return BadRequest();
            }



            Module Module = Mapper.Map<Module>(ModuleDTO);
            ModuleRepo.Update(Module);

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
        public IHttpActionResult PostModule(ModuleDTO ModuleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            Module Module = Mapper.Map<Module>(ModuleDTO);
            ModuleRepo.Add(Module);
            ModuleRepo.Save();

            return CreatedAtRoute("DefaultApi", new { id = Module.ID }, Module);
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