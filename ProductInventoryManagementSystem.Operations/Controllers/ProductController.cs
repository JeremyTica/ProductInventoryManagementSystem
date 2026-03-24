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

        /// <summary>
        /// This function is responsible for handling the API request to add a new product to the database collection
        /// </summary>
        /// <param name="productDto">
        /// The data transfer object containing the necessary information for creating a new product in the database collection, including the product details and inventory information
        /// </param>
        /// <returns>
        /// The status code of the API response and a message indicating the success of the operation
        /// </returns>
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
            if (product == null) return NotFound();

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

        /// <summary>
        /// This function is responsible for handling the API request to update an existing product in the database collection
        /// </summary>
        /// <param name="product">
        /// The product to be updated
        /// </param>
        /// <returns>
        /// The status code of the API response and a message indicating the success of the operation
        /// </returns>
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            if (product == null) return BadRequest("Product data is null");
            var existingProduct = _productServices.GetProduct(product.Id);
            if (existingProduct == null) return NotFound("Product not found");

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Category = product.Category;
            existingProduct.SKU = product.SKU;

            _productServices.UpdateProduct(existingProduct);

            return Ok("Product Updated Successfully");
        }

        /// <summary>
        /// This function is responsible for fetching a product from the database collection through a given id and deleting it if it exists.
        /// </summary>
        /// <param name="id">
        /// The id of the product to be deleted
        /// </param>
        /// <returns>
        /// The status code of the API response and a message indicating the success of the operation
        /// </returns>
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = _productServices.GetProduct(id);
            if (product == null) return NotFound("Product not found");

            _productServices.DeleteProduct(id);

            return Ok("Product Deleted Successfully");
        }
    }
}
