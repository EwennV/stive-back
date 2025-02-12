namespace StiveBack.Ressources
{
    public class OrderRessource
    {
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public UserRessource UserRessource { get; set; }

        public OrderRessource() { }
        public OrderRessource(UserRessource userRessource) 
        {
            UserRessource = userRessource;
        }
    }
}
