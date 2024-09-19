using StiveBack.Models.Core;

namespace StiveBack.Models
{
    public class Order: Entity
    {
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<OrderProduct> OrderProduct { get; set; }
        public Order()
        {
            OrderProduct = new List<OrderProduct>();
        }

    }
}