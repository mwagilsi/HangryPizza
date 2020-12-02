namespace HungryPizza.Domain.Entities
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



