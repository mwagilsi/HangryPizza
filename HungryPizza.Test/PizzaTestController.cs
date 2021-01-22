using HungryPizza.Application.Services;
using HungryPizza.Controllers;
using HungryPizzaServices.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizza.Test
{
    [TestClass]
    public class PizzaTestController : BaseTestController
    {
        [TestMethod]
        [Fact(DisplayName = "Busca Pizza por código")]
        public async Task Get()
        {
            IPizzaServices _pizzaServices = new PizzaServices(context, mapper);
            var pizzaController = new PizzaController(_pizzaServices);
            var actionResult = await pizzaController.GetById(1);

            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
            var okObjectResult = (OkObjectResult)actionResult;
            Assert.AreEqual((int)HttpStatusCode.OK, okObjectResult.StatusCode);
            Assert.IsNotNull(okObjectResult.Value);
        }
    }
}
