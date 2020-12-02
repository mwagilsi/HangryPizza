using System.Collections.Generic;

namespace HungryPizza.Domain.Entities
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Flavor { get; set; }
        public double Price { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
