using AutoMapper;
using HungryPizza.Models;
using HungryPizzaDB;
using HungryPizzaServices.IServices;
using HungryPizzaServices.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza.Services
{
    public class PizzaServices : IPizzaServices
    {
        private readonly HungryPizzaContext _context;
        private readonly IMapper _mapper;
        public PizzaServices(HungryPizzaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<PizzaViewModel>> GetPizzas()
        {
            return await _context.Pizzas.AsNoTracking().Select(b => _mapper.Map<PizzaViewModel>(b)).ToListAsync();
        }

        public async Task<PizzaViewModel> PizzaById(int id)
        {
            return  _mapper.Map<PizzaViewModel>(await _context.Pizzas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id));
        }
    }
}
