using Microsoft.AspNetCore.Mvc;
using ProductAPI.Interfaces;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //lista todos los productos
        [HttpGet]
        public IEnumerable<Product> ProductList()
        {
            var productList = _productService.GetProductsList();
            return productList;
        }

        //busca un producto por id
        [HttpGet("{id}")]
        public Product GetProductById(int id)
        {
            return _productService.GetProductById(id);
        }

        //agregar producto
        [HttpPost]
        public Product AddProduct(Product product)
        {
            return _productService.AddProduct(product);
        }

        //actualizar producto
        [HttpPut]
        public Product UpdateProduct(Product producto)
        {
            return _productService.UpdateProduct(producto);
        }

        //borrar producto
        [HttpDelete("{id}")]
        public bool DeleteProduct(int id)
        {
            return _productService.DeleteProduct(id);
        }

        //agregar migraciones
    }
}
