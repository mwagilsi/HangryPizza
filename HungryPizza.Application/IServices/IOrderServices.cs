using HungryPizza.Application.Models;
using HungryPizza.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HungryPizzaServices.IServices
{
    public interface IOrderServices
    {
        Task<List<OrderViewModel>> GetOrdersByCustomer(int id);
        Task<OrderViewModel> GetOrderById(int id);
        Task<Result> AddOrder(OrderViewModel order);
    }
}
