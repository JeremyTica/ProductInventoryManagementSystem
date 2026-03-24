using Microsoft.EntityFrameworkCore;
using ProductInventoryManagementSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventoryManagementSystem.Services
{
    /// <summary>
    /// This class is the database context that will be used by Entity Framework Core to map the corresponding models to database tables
    /// </summary>
    public class ProductDbContext : DbContext
    {
        /// <summary>
        /// This constructor initializes the database context using the specific options
        /// </summary>
        /// <param name="options"></param>
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
    }
}
