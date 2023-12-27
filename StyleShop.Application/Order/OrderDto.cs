using Microsoft.AspNetCore.Identity;

namespace StyleShop.Application.Order
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime OrderedAt { get; set; } = DateTime.UtcNow;

        public string Street { get; set; } = default!;

        public string City { get; set; } = default!;

        public string PostalCode { get; set; } = default!;

        public string Country { get; set; } = default!;

        public int ProductQuantity { get; set; }
        
        public int ProductId { get; set; }

        public Domain.Entities.Product Product { get; set; }

        public int OrderStatusId { get; set; }

        public Domain.Entities.OrderStatus OrderStatus { get; set; }

        public IdentityUser User { get; set; }

        public bool IsVisible { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
