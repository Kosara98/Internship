using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFurnitureShop.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Weight { get; set; }

        public string Barcode { get; set; }

        public decimal Price { get; set; }
    }
}
