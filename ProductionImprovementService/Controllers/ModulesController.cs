﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductionImprovementService.Services.Interfaces;
using ProductionImprovementService.Models;
using System.Web.Http.Description;

namespace ProductionImprovementService.Controllers
{
    public class ModulesController : ApiController
    {
        private readonly IModuleService moduleService;

        public ModulesController(IModuleService moduleService)
        {
            this.moduleService = moduleService;
        }

        [HttpGet]
        [Route("Module/GetModules")]
        public IHttpActionResult GetModules()
        {
            return Content<IList<Module>>(HttpStatusCode.OK, moduleService.GetModules().Result);
        }
        [HttpGet]
        [Route("Module/GetModule/{name}")]        
        public IHttpActionResult GetModuleByName(string name)
        {
            Module module = moduleService.GetModuleByName(name);

            if(module == null)
            {
                return NotFound();
            }
            return Content<Module>(HttpStatusCode.OK, module);
        }
        [HttpPut]
        [Route("Module/UpdateModule")]
        public IHttpActionResult UpdateModule(Module module)
        {
            var response = moduleService.UpdateModule(module);

            if(response.Message.Equals("Success"))
            {
                return Content<string>(HttpStatusCode.OK, response.Message);
            }
            return Content(HttpStatusCode.BadRequest, response.Message);
        }
        [HttpPost]
        [Route("Module/AddModule")]        
        public IHttpActionResult AddModule(Module module)
        {
            if(module == null)
            {
                return Content(HttpStatusCode.BadRequest, "Object module is null");
            }
            var response = moduleService.AddModule(module);
            if(response.Message.Equals("Success"))
            {
                return Content<string>(HttpStatusCode.OK, response.Message);
            }
            return Content(HttpStatusCode.BadRequest, "Error");
        }
        [HttpDelete]
        [Route("Module/DeleteModule/{name}")]        
        public IHttpActionResult DeleteModule(string name)
        {
            if(name == null)
            {
                return Content(HttpStatusCode.BadRequest, "Module name is null");
            }
            var response = moduleService.DeleteModule(name);
            if(response.Message.Equals("Success"))
            {
                return Content<string>(HttpStatusCode.OK, response.Message);
            }
            return Content(HttpStatusCode.BadRequest, "Error");
        }
    }
}
