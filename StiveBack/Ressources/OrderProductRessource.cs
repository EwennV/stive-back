using StiveBack.Ressources.Core;
using System;

namespace StiveBack.Ressources
{
    public class OrderProductRessource : EntityRessource
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public OrderProductRessource() { }
    }
}