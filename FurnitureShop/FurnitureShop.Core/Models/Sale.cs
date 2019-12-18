using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureShop.Core.Models
{
    public class Sale
    {
        public Dictionary<int, int> Products = new Dictionary<int, int>();

        public int Id { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public string Invoice { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public string Client { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
