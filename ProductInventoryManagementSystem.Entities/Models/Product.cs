using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventoryManagementSystem.Entities.Models
{
    /// <summary>
    /// This class represents a product as a model which will be a part of an inventory management system.
    /// </summary>
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public string? SKU { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Inventory? Inventory { get; set; }
    }
}
