using ProductInventoryManagementSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventoryManagementSystem.Services.ProductServices
{
    /// <summary>
    /// This class represents a repository that will be used to manage data access for products within the management system
    /// </summary>
    public class ProductRepository
    {
        ProductDbContext _productDbContext;

        /// <summary>
        /// This constructor is used to inject the database context into the repository, allowing it to perform data access operations on the product data.
        /// </summary>
        /// <param name="productDbContext">
        /// The database context to be used by the repository
        /// </param>
        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        /// <summary>
        /// This function is responsible for adding a new product to the database
        /// </summary>
        /// <param name="product">
        /// The product to be added
        /// </param>
        /// <returns>
        /// The product after it was added to the database
        /// </returns>
        public Product AddProduct(Product product)
        {
            _productDbContext.Products.Add(product);
            _productDbContext.SaveChanges();
            return product;
        }

        /// <summary>
        /// This function is responsible for fetching a product from the database collection through a given id
        /// </summary>
        /// <param name="id">
        /// The id of the product to be retrieved
        /// </param>
        /// <returns>
        /// The product of the given id
        /// </returns>
        public Product? GetProduct(int id)
        {
            return _productDbContext.Products.FirstOrDefault(p => p.Id == id);

        }

        /// <summary>
        /// This function is responsible for fetching all products from the database collection
        /// </summary>
        /// <returns>
        /// An enumerable collection of all products
        /// </returns>
        public IEnumerable<Product> GetAllProducts()
        {
            return _productDbContext.Products.AsEnumerable();
        }

        /// <summary>
        /// This function is responsible for updating an existing product in the database collection. 
        /// It first checks if the product exists, and if it does, it updates the product and saves the changes to the database. 
        /// If the product does not exist, it returns null.
        /// </summary>
        /// <param name="product">
        /// The product to be updated
        /// </param>
        /// <returns>
        /// The updated product
        /// </returns>
        public Product? UpdateProduct(Product product)
        {
            var existingProduct = _productDbContext.Products.Find(product.Id);
            if (existingProduct == null) return null;
            _productDbContext.Products.Update(existingProduct);
            _productDbContext.SaveChanges();
            return existingProduct;
        }
    }
}
