using AutoMapper;
using HungryPizza.Application.Models;
using HungryPizza.Application.Services;
using HungryPizza.Domain.Entities;
using HungryPizza.Infrastructure.Context;
using HungryPizzaServices.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzaServices.Services
{
    public class OrderServices : IOrderServices
    {
        private ICustomerServices _customerServices;
        private IPizzaServices _pizzaServices;
        private readonly HungryPizzaContext _context;
        private readonly IMapper _mapper;
        public OrderServices(ICustomerServices customerServices, IPizzaServices pizzaServices, HungryPizzaContext context, IMapper mapper)
        {
            _customerServices = customerServices;
            _pizzaServices = pizzaServices;
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OrderViewModel>> GetOrdersByCustomer(int id)
        {
            var result = await _context.Orders
                           .Include(i => i.OrderDelivery)
                           .Include(i => i.OrderItems).ThenInclude(ti => ti.OrderItemSplits).ThenInclude(ti => ti.Pizza)
                           .Where(w => w.CustomerId == id).AsNoTracking().ToListAsync();

            return result.Select(r => _mapper.Map<OrderViewModel>(r)).ToList();
        }

        public async Task<OrderViewModel> GetOrderById(int id)
        {
            var result = await _context.Orders
                           .Include(i => i.OrderDelivery)
                           .Include(i => i.OrderItems).ThenInclude(ti => ti.OrderItemSplits).ThenInclude(ti => ti.Pizza)
                           .FirstOrDefaultAsync(f => f.Id == id);

            return _mapper.Map<OrderViewModel>(result);
        }
        public async Task<Result> AddOrder(OrderViewModel order)
        {
            try
            {
                if (order.OrderItems.Count == 0)
                    return new Result() { Success = false, Message = "O Pedido deve ter ao menos uma pizza." };

                if (order.OrderItems.Count > 10)
                    return new Result() { Success = false, Message = "O Pedido máximo é de 10 pizzas." };

                if (order.OrderItems.Any(a => a.OrderItemSplits.Where(w => w.OrderItemId == a.Id).Count() > 2))
                    return new Result() { Success = false, Message = "Cada pizza podem ter no máximo 2 sabores." };

                // Se o Pedido tiver um cliente cadastrado pega os dados do cliente.
                if (order.CustomerId.HasValue)
                {
                    var _customerDB = await _customerServices.GetCustomerById(order.CustomerId.Value);
                    if(_customerDB != null)
                    {
                        order.OrderDelivery.ZipCode = _customerDB.ZipCode;
                        order.OrderDelivery.Address1 = _customerDB.Address1;
                        order.OrderDelivery.Number = _customerDB.Number;
                        order.OrderDelivery.Address2 = _customerDB.Address2;
                        order.OrderDelivery.District = _customerDB.District;
                        order.OrderDelivery.City = _customerDB.City;
                        order.OrderDelivery.State = _customerDB.State;
                        order.OrderDelivery.Country = _customerDB.Country;
                    }
                }
                
                // Totaliza o pedido.
                double orderTotal = 0;
                foreach (var item in order.OrderItems)
                {
                    double orderItemTotal = 0;
                    foreach (var itemSplit in item.OrderItemSplits)
                    {
                        var price = itemSplit.Pizza.Price;
                        if (string.IsNullOrEmpty(itemSplit.Pizza.Flavor))
                        {
                            var pizzaDB = await _pizzaServices.PizzaById(itemSplit.Pizza.Id);
                            price = pizzaDB.Price;
                            itemSplit.PizzaId = pizzaDB.Id;
                            itemSplit.Price = price;
                            itemSplit.Pizza = null;
                        }

                        orderItemTotal += item.SplitPie ? price / 2 : price;
                    }

                    item.Total = orderItemTotal;
                    orderTotal += item.Total;
                }

                order.Total = orderTotal;

                await _context.Orders.AddAsync(_mapper.Map<Order>(order));
                await _context.SaveChangesAsync();

                return new Result() { Success = true, Message = "Pedido incluído com sucesso!" };
            }
            catch (Exception e)
            {
                return new Result() { Success = false, Message = e.Message }; 
            }
        }
    }
}
