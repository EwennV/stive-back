using StiveBack.Ressources.Core;

namespace StiveBack.Ressources
{
    public class CategoryRessource: EntityRessource
    {
        public string Name { get; set; }
        public int? CategoryRessourceParentId { get; set; }
        public CategoryRessource? CategoryRessourceParent { get; set; }

        public CategoryRessource()
        {
        }
        public CategoryRessource(CategoryRessource? categoryRessource)
        {
            CategoryRessourceParent = categoryRessource;
        }
    }
}
