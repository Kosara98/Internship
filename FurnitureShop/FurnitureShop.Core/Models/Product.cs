using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureShop.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
    }
}
