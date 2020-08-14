using HungryPizza.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HungryPizzaServices.IServices
{
    public interface IOrderServices
    {
        Task<List<OrderViewModel>> GetOrdersByCustomer(int id);
        Task<OrderViewModel> GetOrderById(int id);
        Task<Tuple<bool, string>> AddOrder(OrderViewModel order);
    }
}
