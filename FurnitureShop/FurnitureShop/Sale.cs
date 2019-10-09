using System;
using System.Collections.Generic;

namespace FurnitureShop
{
    public class Sale
    {
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public string Invoice { get; set; }
        public Dictionary<string, int> Products = new Dictionary<string, int>();
        public string Product { get; set; }
        public int Quantity { get; set; }
        public string Client { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
