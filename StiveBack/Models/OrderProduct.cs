using StiveBack.Models.Core;

namespace StiveBack.Models
{
    public class OrderProduct: Entity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public OrderProduct() { }
    }
}
