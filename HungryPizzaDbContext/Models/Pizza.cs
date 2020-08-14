using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizza.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Flavor { get; set; }
        public double Price { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
