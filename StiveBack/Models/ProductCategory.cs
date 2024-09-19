using StiveBack.Models.Core;

namespace StiveBack.Models
{
    public class ProductCategory: Entity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Product Product { get; set; }
        public ProductCategory() { }
    }
}
