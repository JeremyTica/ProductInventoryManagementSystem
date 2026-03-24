using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventoryManagementSystem.Entities.Models
{
    /// <summary>
    /// This class represents an inventory as a model, which will be used to manage the stock of products.
    /// </summary>
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int QuantityInStock { get; set; }
        public int ReorderLevel { get; set; }
    }
}
