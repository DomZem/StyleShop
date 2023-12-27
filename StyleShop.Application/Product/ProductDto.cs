﻿namespace StyleShop.Application.Product
{

    public class ProductDto
    {
        public int Id { get; set; } 

        public string Name { get; set; } = default!;

        public string? Description { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int ProductCategoryId { get; set; }

        public Domain.Entities.ProductCategory ProductCategory { get; set; }
    }
}
