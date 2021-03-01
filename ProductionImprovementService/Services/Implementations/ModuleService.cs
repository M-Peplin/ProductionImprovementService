using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductionImprovementService.Services.Interfaces;
using ProductionImprovementService.EF;
using ProductionImprovementService.ModelsDTO;
using ProductionImprovementService.Models;

namespace ProductionImprovementService.Services.Implementations
{
    public class ModuleService : IModuleService
    {
        private readonly CalculatorContext context;

        public ModuleService(CalculatorContext context)
        {
            this.context = context;
        }

        public OperationSuccessDTO<Module> AddModule(Module module)
        {
            context.Module.Add(module);
            context.SaveChanges();
            return new OperationSuccessDTO<Module> { Message = "Success" };
        }

        public Module GetModuleByName(string moduleName)
        {
            return context.Module.Where(module => module.Name == moduleName).FirstOrDefault();
        }

        public OperationSuccessDTO<List<Module>> GetModules()
        {
            List<Module> modules = context.Module.ToList();
            return new OperationSuccessDTO<List<Module>> { Message = "Success", Result = modules };
        }

        public OperationSuccessDTO<Module> UpdateModule(Module module)
        {
            var mod = context.Module.Where(m => m.Name == module.Name).FirstOrDefault();
            //maybe automapper here?
            mod.Name = module.Name;
            mod.Price = module.Price;
            mod.Weight = module.Weight;
            mod.AssemblyTime = module.AssemblyTime;
            mod.Code = module.Code;
            mod.Description = module.Description;
            context.SaveChanges();
            return new OperationSuccessDTO<Module> { Message = "Success" };
            
        }
    }
}