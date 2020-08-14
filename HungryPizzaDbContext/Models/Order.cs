using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizza.Models
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



