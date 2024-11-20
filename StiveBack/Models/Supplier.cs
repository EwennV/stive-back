using StiveBack.Models.Core;


namespace StiveBack.Models
{
    public class Supplier: Entity
    {
        public string Name { get; set; }
        public string? Siret { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public List<Product>? Product { get; set; }

        public Supplier()
        {
            Product = new List<Product>();
        }
    }

}