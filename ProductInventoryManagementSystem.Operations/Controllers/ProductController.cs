using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductInventoryManagementSystem.Entities.Models;
using ProductInventoryManagementSystem.Operations.DTOs;
using ProductInventoryManagementSystem.Services.Interfaces;

namespace ProductInventoryManagementSystem.Operations.Controllers
{
    /// <summary>
    /// This class is the controller that will handle the API requests related to products in the management system
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductServices _productServices;

        /// <summary>
        /// This is the constructor used to inject the product services into the controller
        /// </summary>
        /// <param name="productServices">
        /// The product services to be used by the controller for handling product-related operations
        /// </param>
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductDto productDto)
        {
            if (productDto == null) return BadRequest("Product data is null");

            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Category = productDto.Category,
                SKU = productDto.SKU,
                CreatedDate = DateTime.Now,

                Inventory = new Inventory
                {
                    QuantityInStock = productDto.QuantityInStock,
                    ReorderLevel = productDto.ReorderLevel
                }
            };

            _productServices.AddProduct(product);

            return Ok("Product Added Successfully");
        }

        /// <summary>
        /// This function is responsible for handling the API request to retrieve a product by its id
        /// </summary>
        /// <param name="id">
        /// The id of the product to be retrieved from the database
        /// </param>
        /// <returns>
        /// The status code of the API response and the product
        /// </returns>
        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = _productServices.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        /// <summary>
        /// This function is responsible for handling the API requests to retrieve all products from the database collection
        /// </summary>
        /// <returns>
        /// The status of the API response and the products
        /// </returns>
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = _productServices.GetAllProducts();
            return Ok(products);
        }
    }
}
