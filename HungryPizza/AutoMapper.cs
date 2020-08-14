using AutoMapper;
using HungryPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Pizza, PizzaViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<OrderDelivery, OrderDeliveryViewModel>().ReverseMap();
            CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();
            CreateMap<OrderItemSplit, OrderItemSplitViewModel>().ReverseMap();
        }
    }
}
