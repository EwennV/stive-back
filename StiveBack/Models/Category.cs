using StiveBack.Models.Core;

namespace StiveBack.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public int? CategoryParentId { get; set; }
        public Category? CategoryParent { get; set; }
        public Category() { }
        public Category(Category? categoryParent)
        {

            CategoryParent = categoryParent;
        }
    }
}
