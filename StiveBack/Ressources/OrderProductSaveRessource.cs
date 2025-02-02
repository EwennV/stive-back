using StiveBack.Ressources.Core;
using System;

namespace StiveBack.Ressources
{
    public class OrderProductSaveRessource
    {
        public int? OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public OrderProductSaveRessource() { }
    }
}