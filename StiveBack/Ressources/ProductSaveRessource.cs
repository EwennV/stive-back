namespace StiveBack.Ressources
{
    public class ProductSaveRessource
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
        public int SupplierId { get; set; }
        public List<int>? CategoryIds { get; set; }

        public ProductSaveRessource()
        {
            CategoryIds = new List<int>();
        }
        public ProductSaveRessource(List<int> categoryIds) : this()
        {
            CategoryIds = categoryIds;
        }
    }
}
