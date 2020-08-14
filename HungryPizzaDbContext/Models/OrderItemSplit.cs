using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizza.Models
{
    public class OrderItemSplit
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public double Price { get; set; }
    }
}



