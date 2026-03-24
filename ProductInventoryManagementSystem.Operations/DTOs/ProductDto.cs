using ProductInventoryManagementSystem.Entities.Models;

namespace ProductInventoryManagementSystem.Operations.DTOs
{
    public class ProductDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public string? SKU { get; set; }
        public int QuantityInStock { get; set; }
        public int ReorderLevel { get; set; }
    }
}
