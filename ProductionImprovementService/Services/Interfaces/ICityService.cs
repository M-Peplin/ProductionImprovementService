using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductionImprovementService.Models;
using ProductionImprovementService.ModelsDTO;

namespace ProductionImprovementService.Services.Interfaces
{
    public interface ICityService
    {
        City GetCityByName(string cityname);
        OperationSuccessDTO<IList<City>> GetCities();
        OperationResultDTO UpdateCostOfWorkingHour(string cityName, double workingHourCost);
        OperationResultDTO UpdateTransportCost(string cityName, double transportCost);
        OperationResultDTO AddCity(City city);
        OperationResultDTO DeleteCity(string cityName);

    }
}
