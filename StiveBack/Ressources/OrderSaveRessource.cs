namespace StiveBack.Ressources
{
    public class OrderSaveRessource
    {
        public int UserId { get; set; }
        public List<OrderProductSaveRessource> Products { get; set; }

        public OrderSaveRessource()
        {
            Products = new List<OrderProductSaveRessource>();
        }
    }
}
