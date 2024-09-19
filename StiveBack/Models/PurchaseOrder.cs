using StiveBack.Models.Core;

namespace StiveBack.Models
{
    public class PurchaseOrder: Entity
    {
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public List<PurchaseOrderProduct> PurchaseOrderProduct { get; set; }

        public PurchaseOrder()
        {
            PurchaseOrderProduct = new List<PurchaseOrderProduct>();
        }
    }
}
