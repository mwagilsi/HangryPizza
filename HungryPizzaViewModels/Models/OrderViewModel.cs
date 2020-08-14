using System;
using System.Collections.Generic;

namespace HungryPizza.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
        public int? CustomerId { get; set; }
        public CustomerViewModel Customer { get; set; }
        public OrderDeliveryViewModel OrderDelivery { get; set; }
        public double Total { get; set; }
    }
}
