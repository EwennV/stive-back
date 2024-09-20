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
        public List<int> ProductCategories { get; set; }
        public List<int> OrderProducts { get; set; }
        public List<int> PurchaseOrderProducts { get; set; }

        public ProductRessource()
        {
            ProductCategories = new List<int>();
            OrderProducts = new List<int>();
            PurchaseOrderProducts = new List<int>();
        }
        public ProductRessource(List<int> productCategories, List<int> orderProducts, List<int> purchaseOrderProducts) : this()
        {
            ProductCategories = productCategories;
            OrderProducts = orderProducts;
            PurchaseOrderProducts = purchaseOrderProducts;
        }
    }
}
