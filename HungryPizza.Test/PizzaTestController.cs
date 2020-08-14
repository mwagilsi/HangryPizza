using AutoMapper;
using HungryPizza.Controllers;
using HungryPizza.Models;
using HungryPizza.Services;
using HungryPizzaDB;
using HungryPizzaServices.IServices;
using HungryPizzaServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;

namespace HungryPizza.Test
{
    [TestClass]
    public class PizzaTestController
    {
        [TestMethod]
        public async Task Get()
        {
                                
            var optionsBuilder = new DbContextOptionsBuilder<HungryPizzaContext>()
                .UseSqlServer("Server=bd.asp.hostazul.com.br,3533;Database=10337_hungrypizza;Uid=10337_hungrypizza;Password=hungrypizza@1;").Options;
            var context = new HungryPizzaContext(optionsBuilder);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapper());
            });
            var mapper = mockMapper.CreateMapper();

            IPizzaServices _pizzaServices = new PizzaServices(context, mapper);
            var orderController = new PizzaController(_pizzaServices);
            var actionResult = await orderController.GetById(1);

            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
            var okObjectResult = (OkObjectResult)actionResult;
            Assert.AreEqual((int)HttpStatusCode.OK, okObjectResult.StatusCode);
            Assert.IsNotNull(okObjectResult.Value);
        }
    }
}
