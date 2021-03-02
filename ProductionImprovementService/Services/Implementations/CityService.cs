﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductionImprovementService.Services.Interfaces;
using ProductionImprovementService.Models;
using ProductionImprovementService.ModelsDTO;
using ProductionImprovementService.EF;

namespace ProductionImprovementService.Services.Implementations
{
    public class CityService : ICityService
    {
        private readonly CalculatorContext context;
        public CityService(CalculatorContext context)
        {
            this.context = context;
        }

        public City GetCityByName(string cityName)
        {
            return context.City.Where(c => c.Name == cityName).FirstOrDefault();
        }

        public OperationSuccessDTO<IList<City>> GetCities()
        {
            List<City> cities = context.City.ToList();
            return new OperationSuccessDTO<IList<City>> { Message = "Success", Result = cities };
        }

        public OperationResultDTO AddCity(City city)
        {
            context.City.Add(city);
            context.SaveChanges();
            return new OperationSuccessDTO<Module> { Message = "Success"};
        }

        public OperationResultDTO UpdateCostOfWorkingHour(string cityName, double workingHourCost)
        {
            var updateCity = context.City.Where(c => c.Name == cityName).FirstOrDefault();
            if(updateCity == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"City with name {cityName} doesn't exist" };
            }
            updateCity.CostOfWorkingHour = workingHourCost;
            context.SaveChanges();
            return new OperationSuccessDTO<Module> { Message = "Success" };
        }

        public OperationResultDTO UpdateTransportCost(string cityName, double transportCost)
        {
            var updateCity = context.City.Where(c => c.Name == cityName).FirstOrDefault();
            if(updateCity == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"City with name: {cityName} doesn't exist" };
            }
            updateCity.TransportCost = transportCost;
            context.SaveChanges();
            return new OperationSuccessDTO<Module> { Message = "Success" };
        }

        public OperationResultDTO DeleteCity(string cityName)
        {
            var city = GetCityByName(cityName);
            if(city == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"City with name {cityName} doesn't exist" };
            }
            context.City.Remove(city);
            context.SaveChanges();

            return new OperationSuccessDTO<Module> { Message = "Success" };
        }

    }
}