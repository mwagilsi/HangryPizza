using AutoMapper;
using HungryPizza.Models;
using HungryPizzaDB;
using HungryPizzaServices.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly HungryPizzaContext _context;
        private readonly IMapper _mapper;
        public CustomerServices(HungryPizzaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CustomerViewModel>> GetCustomers()
        {
            var customers = await _context.Customers.Select(c => _mapper.Map<CustomerViewModel>(c)).ToListAsync();
            customers.ForEach(f => f.Password = null);
            return customers;
        }
        public async Task<bool> IsCustomerExits(string userName)
        {
            return await _context.Customers.AnyAsync(a => a.UserName == userName);
        }
        public async Task<CustomerViewModel> CustomerData(string userName, string password)
        {
            var user = await _context.Customers.FirstOrDefaultAsync(f => f.UserName == userName && f.Password == password);
            return _mapper.Map<CustomerViewModel>(user);
        }

        public async Task<CustomerViewModel> GetCustomerById(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            customer.Password = null;
            return _mapper.Map<CustomerViewModel>(customer);
        }
        public async Task<CustomerViewModel> GetUserName(string userName)
        {
            var customer = _mapper.Map<CustomerViewModel>(await _context.Customers.FirstOrDefaultAsync(x => x.UserName == userName));
            customer.Password = null;
            return customer;
        }
    }
}
