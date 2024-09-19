using StiveBack.Ressources.Core;

namespace StiveBack.Ressources
{
    public class PurchaseOrderRessource: EntityRessource
    {
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public List<ProductRessource> Products { get; set; }

        public PurchaseOrderRessource()
        {
            Products = new List<ProductRessource>();
        }
        public PurchaseOrderRessource(List<ProductRessource> products): this()
        {
            Products = products;
        }
    }
}
