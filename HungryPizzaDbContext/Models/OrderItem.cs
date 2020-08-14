using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizza.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public bool SplitPie { get; set; }
        public List<OrderItemSplit> OrderItemSplits { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
    }
}



