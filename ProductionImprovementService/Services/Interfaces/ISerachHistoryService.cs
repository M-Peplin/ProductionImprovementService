using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductionImprovementService.Models;
using ProductionImprovementService.ModelsDTO;

namespace ProductionImprovementService.Services.Interfaces
{
    interface ISerachHistoryService
    {
        ResultCostDTO GetSearchHistory(string cityName, ModuleListDTO moduleListDTO);
        OperationSuccessDTO<IList<SearchHistory>> GetSearchHistories();
        OperationResultDTO AddSearchHistory(SearchHistory searchHistory);
    }
}
