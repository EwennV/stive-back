using StiveBack.Ressources.Core;

namespace StiveBack.Ressources
{
    public class CategoryRessource: EntityRessource
    {
        public string Name { get; set; }
        public CategoryRessource? CategoryParent { get; set; }

        public CategoryRessource() { }

        public CategoryRessource(CategoryRessource categoryParent)
        {
            CategoryParent = categoryParent;
        }

    }
}
