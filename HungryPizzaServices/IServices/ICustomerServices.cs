using HungryPizza.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HungryPizzaServices.IServices
{
    public interface ICustomerServices
    {
        Task<List<CustomerViewModel>> GetCustomers();
        Task<bool> IsCustomerExits(string userName);
        Task<CustomerViewModel> CustomerData(string userName, string password);
        Task<CustomerViewModel> GetCustomerById(int id);
        Task<CustomerViewModel> GetUserName(string userName);
    }
}
