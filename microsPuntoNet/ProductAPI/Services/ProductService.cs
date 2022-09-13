using ProductAPI.Data;
using ProductAPI.Interfaces;
using ProductAPI.Models;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly DbContextProduct _dbContext;
        public ProductService(DbContextProduct dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetProductsList()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
        }

        public Product AddProduct(Product product)
        {
            var result = _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public Product UpdateProduct(Product product)
        {
            var result = _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteProduct(int id)
        {
            var filteredData = _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }
    }
}
