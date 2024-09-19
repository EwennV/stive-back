﻿using StiveBack.Models.Core;


namespace StiveBack.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Reference { get; set; }
        public float SellPrice { get; set; }
        public float SellTva { get; set; }
        public int Quantity { get; set; }
        public int MinThreshold { get; set; }
        public int ReorderQuantity { get; set; }
        public string BottlingDate { get; set; }
        public float PurchasePrice { get; set; }
        public float PurchaseTva { get; set; }
        public string House { get; set; }
        public string Photo { get; set; }
        public bool AutoProvisioning { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public List<ProductCategory> ProductCategorie { get; set; }
        public List<OrderProduct> OrderProduct { get; set; }
        public List<PurchaseOrderProduct> PurchaseOrderProduct { get; set; }

        public Product()
        {
            ProductCategorie = new List<ProductCategory>();
            OrderProduct = new List<OrderProduct>();
            PurchaseOrderProduct = new List<PurchaseOrderProduct>();
        }
    }
}