using ProductionImprovementService.EF;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using ProductionImprovementService.Services.Interfaces;
using ProductionImprovementService.Services.Implementations;
using SimpleInjector.Integration.WebApi;
using ProductionImprovementService.App_Start;

namespace ProductionImprovementService
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();
            container.Register<CalculatorContext>(Lifestyle.Scoped);
            container.Register<ICityService, CityService>(Lifestyle.Scoped);
            container.Register<IModuleService, ModuleService>(Lifestyle.Scoped);
            container.Register<ICalculatorCostService, CalculatorCostService>(Lifestyle.Scoped);
            container.Register<ISearchHistoryService, SearchHistoryService>(Lifestyle.Scoped);
            container.Register<IShowResultService, ShowResultService>(Lifestyle.Scoped);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
            AreaRegistration.RegisterAllAreas();
        }
    }
}
