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
<<<<<<< HEAD
=======

>>>>>>> e81f41d8d62e39f78e6a2400ff47e50b401fb2df
            CategoryParent = categoryParent;
        }
    }
}
