namespace StyleShop.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; } 

        public DateTime OrderedAt { get; set; } = DateTime.UtcNow;

        public OrderAddress OrderAddress { get; set; } = default!;

        public int ProductQuantity { get; set; }

        public int ProductId { get; set; }  

        public Product Product { get; set; } = default!;

        public int OrderStatusId { get; set; }

        public OrderStatus OrderStatus { get; set; } = default!;
    }
}
