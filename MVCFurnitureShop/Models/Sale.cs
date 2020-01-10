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

        [Display(Name = "Sale Date")]
        [DataType(DataType.Date)]
        public DateTime SaleDate { get; set; }

        [StringLength(10,MinimumLength = 10)]
        [Required]
        public string Invoice { get; set; }

        [Display(Name = "Client")]
        public string ClientName { get; set; }

        [Display(Name = "Products")]
        public ICollection<ProductSale> ProductSales { get; set; }
    }
}
