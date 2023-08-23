using Microsoft.AspNetCore.Mvc;
using Repository_Patterns.Models;
using Repository_Patterns.Repository;

namespace Repository_Patterns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IRepository<Product> _productRepository;
        public ProductsController(IRepository<Product> ProductRepository) { _productRepository = ProductRepository; }

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return products != null ? Ok(products) : NoContent();
        }



        [HttpGet]
        [Route("[Action]/{prodId}")]
        public IActionResult GetproductById(int prodId)
        {
            var product = _productRepository.GetProductById(prodId);
            return product != null ? Ok(product) : NoContent();
        }


        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            bool isCreated = await _productRepository.AddAsync(product);
            return Ok(isCreated ? "product Created Sucessfully." : "product Creation Failed.");
        }

        [HttpDelete]
        [Route("[Action]/{prodId}")]
        public async Task<IActionResult> DeleteProduct(int prodId)
        {
            var user = _productRepository.GetProductById(prodId);
            bool isDeleted = await _productRepository.DeleteAsync(user);
            return Ok(isDeleted ? "User Deleted Sucessfully." : "User Deletion Failed.");
        }
    }
}
