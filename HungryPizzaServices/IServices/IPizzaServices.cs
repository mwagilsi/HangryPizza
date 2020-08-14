
using HungryPizza.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HungryPizzaServices.IServices
{
    public interface IPizzaServices
    {
        Task<List<PizzaViewModel>> GetPizzas();
        Task<PizzaViewModel> PizzaById(int id);
    }
}
