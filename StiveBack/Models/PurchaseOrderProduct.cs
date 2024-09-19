using StiveBack.Models.Core;

namespace StiveBack.Models
{
    public class PurchaseOrderProduct: Entity
    {
        public int ProductId { get; set; }
        public int PurchaseOrderId { get; set; }
        public Product Product { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }

        public PurchaseOrderProduct() { }
    }
}
