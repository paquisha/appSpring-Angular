﻿using ProductAPI.Models;

namespace ProductAPI.Interfaces
{
    public interface IProductService
    {
        public IEnumerable<Product> GetProductsList();
        public Product GetProductById(int id);
        public Product AddProduct(Product product);
        public Product UpdateProduct(Product product);
        public bool DeleteProduct(int id);
    }
}
