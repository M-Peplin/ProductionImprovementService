using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductionImprovementService.Models;
using ProductionImprovementService.ModelsDTO;

namespace ProductionImprovementService.Services.Interfaces
{
    interface IModuleService
    {
        Module GetModuleByName(string moduleName);
        OperationSuccessDTO<List<Module>> GetModules();
        OperationSuccessDTO<Module> AddModule(Module module);
        OperationSuccessDTO<Module> UpdateModule(Module module);
        OperationSuccessDTO<Module> DeleteModule(Module module);
    }
}
