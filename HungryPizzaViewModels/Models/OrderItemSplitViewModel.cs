using System;
using System.Collections.Generic;

namespace HungryPizza.Models
{
    public class OrderItemSplitViewModel
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public int PizzaId { get; set; }
        public PizzaViewModel Pizza { get; set; }
        public double Price { get; set; }
    }
}
