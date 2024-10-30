using StiveBack.Models;
using StiveBack.Ressources.Core;

namespace StiveBack.Ressources
{
    public class ProductRessource: EntityRessource
    {
        public string Name { get; set; }
        public string Reference { get; set; }
        public float SellPrice { get; set; }
        public float SellTva { get; set; }
        public int Quantity { get; set; }
        public int MinThreshold { get; set; }
        public int ReorderQuantity { get; set; }
        public string BottlingDate { get; set; }
        public float PurchasePrice { get; set; }
        public float PurchaseTva { get; set; }
        public string House { get; set; }
        public string ImageName { get; set; }
        public bool AutoProvisioning { get; set; }
        public SupplierRessource Supplier { get; set; }
        public List<CategoryRessource>? ProductCategories { get; set; }

        public ProductRessource()
        {
            ProductCategories = new List<CategoryRessource>();
        }
        public ProductRessource(List<CategoryRessource> categories)
        {
            ProductCategories = categories;
        }
    }
}
