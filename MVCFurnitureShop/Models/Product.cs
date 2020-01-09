using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFurnitureShop.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [StringLength(35, MinimumLength = 3)]
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        [Required(ErrorMessage = "Required")]
        public decimal Weight { get; set; }

        [StringLength(13, MinimumLength = 13)]
        [Required(ErrorMessage = "Required")]
        public string Barcode { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        [Required(ErrorMessage = "Required")]
        public decimal Price { get; set; }
    }
}
