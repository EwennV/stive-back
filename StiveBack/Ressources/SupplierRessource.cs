using StiveBack.Ressources.Core;

namespace StiveBack.Ressources
{
    public class SupplierRessource: EntityRessource
    {
        public string Name { get; set; }
        public string Siret { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }

        public SupplierRessource() { }
    }
}
