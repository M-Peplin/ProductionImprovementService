using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductionImprovementService.ModelsDTO;

namespace ProductionImprovementService.Services.Interfaces
{
    public interface ICalculatorCostService
    {
        OperationResultDTO CalculateCost(string cityName, ModuleListDTO moduleListDTO);
    }
}
