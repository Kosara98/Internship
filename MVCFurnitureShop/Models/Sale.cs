using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFurnitureShop.Models
{
    public class Sale
    {
        public int SaleId { get; set; }

        [DataType(DataType.Date)]
        public DateTime SaleDate { get; set; }

        public string Invoice { get; set; }

        public string Product { get; set; }

        public int Quantity { get; set; }

        public Client Client { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
