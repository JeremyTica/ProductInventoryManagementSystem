using ProductInventoryManagementSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventoryManagementSystem.Services.Interfaces
{
    /// <summary>
    /// This interface is this abstraction of the product services, which will be implemented by the ProductService class to provide the necessary functionalities for managing products within the inventory management system
    /// </summary>
    public interface IProductServices
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        void DeleteProduct(int id);

    }
}
