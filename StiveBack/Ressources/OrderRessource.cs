using StiveBack.Ressources.Core;

namespace StiveBack.Ressources
{
    public class OrderRessource : EntityRessource
    {
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public List<OrderProductRessource> OrderProducts { get; set; }

        public OrderRessource()
        {
            OrderProducts = new List<OrderProductRessource>();
        }
    }
}
