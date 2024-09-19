using StiveBack.Ressources.Core;

namespace StiveBack.Ressources
{
    public class CategoryRessource: EntityRessource
    {
        public string Name { get; set; }
        public int? CategoryRessourceParentId { get; set; }
        public CategoryRessource? CategoryRessourceParent { get; set; }
        public List<ProductRessource> ProductRessources { get; set; }

        public CategoryRessource()
        {
            ProductRessources = new List<ProductRessource>();
        }
        public CategoryRessource(CategoryRessource? categoryRessource, List<ProductRessource> productRessources)
        {
            CategoryRessourceParent = categoryRessource;
            ProductRessources = productRessources;
        }
    }
}
