﻿using StyleShop.Application.Product;
using StyleShop.Domain.Entities;

namespace StyleShop.Application.Services
{
    public interface IProductService
    {
        Task Create(ProductDto product);

        Task<IEnumerable<ProductCategory>> GetProductCategories();
    }
}
