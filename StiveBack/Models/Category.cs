using StiveBack.Models.Core;

namespace StiveBack.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public int? CategoryParentId { get; set; }
        public Category? CategoryParent { get; set; }
        //public List<Product> Products { get; set; }
        public Category()
        {
            //Products = new List<Product>();
        }
        public Category(List<Product> products, Category? categoryParent)
        {
            //Products = products;
            CategoryParent = categoryParent;
        }
    }
}
