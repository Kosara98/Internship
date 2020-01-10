using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFurnitureShop.Models
{
    public class ProductSale
    {
        public int SaleId { get; set; }

        public string ProductName { get; set; }

        [RegularExpression("^[0-9]+$")]
        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }
    }
}
