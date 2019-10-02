using System;
using System.Collections.Generic;

namespace FurnitureShop
{
    public class Sales
    {
       

        public DateTime SaleDate { get; set; }
        public string Client { get; set; }
        public List<string> Products { get; set; }
        public List<int> Quantity { get; set; }
        public double TotalPrice { get; set; }
    }
}
