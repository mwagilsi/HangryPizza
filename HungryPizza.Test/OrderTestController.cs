using AutoMapper;
using HungryPizza.Application.Models;
using HungryPizza.Application.Services;
using HungryPizza.Controllers;
using HungryPizza.Infrastructure.Context;
using HungryPizzaServices.IServices;
using HungryPizzaServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace HungryPizza.Test
{
    [TestClass]
    public class OrderTestController
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
            ICustomerServices _customerServices = new CustomerServices(context, mapper);
            IOrderServices _orderServices = new OrderServices(_customerServices, _pizzaServices, context, mapper);
            var orderController = new OrderController(_orderServices);
            var actionResult = await orderController.GetById(1);

            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
            var okObjectResult = (OkObjectResult)actionResult;
            Assert.AreEqual((int)HttpStatusCode.OK, okObjectResult.StatusCode);
            Assert.IsNotNull(okObjectResult.Value);
        }

        [TestMethod]
        public async Task Post()
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
            ICustomerServices _customerServices = new CustomerServices(context, mapper);
            IOrderServices _orderServices = new OrderServices(_customerServices, _pizzaServices, context, mapper);
            var orderController = new OrderController(_orderServices);

            var oderViewModel = new OrderViewModel()
            {
                Date = DateTime.Now,
                OrderDelivery = new OrderDeliveryViewModel()
                {
                    ZipCode = "13334-170",
                    Address1 = "Avenida Presidente Kennedy",
                    Number = "1500",
                    District = "Cidade Nova",
                    City = "Indaiatuba",
                    State = "São Paulo",
                    Country = "Brasil"
                },
                OrderItems = new List<OrderItemViewModel>()
                {
                    new OrderItemViewModel()
                    {
                        Quantity = 1,
                        SplitPie = false,
                        OrderItemSplits = new List<OrderItemSplitViewModel>()
                        {
                            new OrderItemSplitViewModel()
                            {
                                Pizza = new PizzaViewModel()
                                {
                                    Id = 1
                                }
                            }
                        }
                    }
                }
            };

            var actionResult = await orderController.Add(oderViewModel);

            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
            var okObjectResult = (OkObjectResult)actionResult;
            Assert.AreEqual((int)HttpStatusCode.OK, okObjectResult.StatusCode);
            Assert.IsNotNull(okObjectResult.Value);
        }
    }
}
