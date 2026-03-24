using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
