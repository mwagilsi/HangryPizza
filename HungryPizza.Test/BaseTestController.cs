using AutoMapper;
using HungryPizza.Application.Services;
using HungryPizza.Controllers;
using HungryPizza.Infrastructure.Context;
using HungryPizzaServices.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace HungryPizza.Test
{
    [TestClass]
    public class BaseTestController
    {
        public IConfigurationBuilder builder;
        public DbContextOptions<HungryPizzaContext> optionsBuilder;
        public HungryPizzaContext context;
        public IMapper mapper;
        public BaseTestController()
        {
            string curDir = Directory.GetCurrentDirectory();

            builder = new ConfigurationBuilder()
           .SetBasePath(curDir)
           .AddJsonFile("appsettings.json");

            optionsBuilder = new DbContextOptionsBuilder<HungryPizzaContext>()
                .UseSqlServer(builder.Build().GetConnectionString("DefaultConnection")).Options;

            context = new HungryPizzaContext(optionsBuilder);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapper());
            });

            mapper = mockMapper.CreateMapper();
        }
    }
}
