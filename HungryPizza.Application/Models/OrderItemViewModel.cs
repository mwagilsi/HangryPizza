using System.Collections.Generic;

namespace HungryPizza.Application.Models
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public List<OrderItemSplitViewModel> OrderItemSplits { get; set; }
        public bool SplitPie { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
    }
}
