using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProductionImprovementService.Models;


namespace ProductionImprovementService.EF
{
    public class CalculatorContext : DbContext
    {
        public CalculatorContext() : base("name=ConnectionString") { }

        public DbSet<SearchHistory> SearchHistory { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<City> City { get; set; }
    }
}