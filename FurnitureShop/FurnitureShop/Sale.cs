using System;
using System.Collections.Generic;

namespace FurnitureShop
{
    public class Sale
    {
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public string Invoice { get; set; }
        public Dictionary<int, int> Products = new Dictionary<int, int>();
    }
}
