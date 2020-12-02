using System;
using System.Collections.ObjectModel;

namespace HungryPizza.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Collection<OrderItem> OrderItems { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public OrderDelivery OrderDelivery { get; set; }
        public double Total { get; set; }
    }
}



