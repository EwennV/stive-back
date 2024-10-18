using StiveBack.Ressources.Core;

namespace StiveBack.Ressources
{
    public class CategoryRessource: EntityRessource
    {
        public string Name { get; set; }
        public int? CategoryRessourceParentId { get; set; }

        public CategoryRessource() { }

    }
}
