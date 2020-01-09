using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFurnitureShop.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "Required")]
        public string Address { get; set; }

        [StringLength(9, MinimumLength = 9)]
        [Required(ErrorMessage = "Required")]
        public string Bulstat { get; set; }

        [Display(Name = "Registered Vat")]
        public bool RegisteredVat { get; set; }

        [StringLength(35, MinimumLength = 3)]
        [Required(ErrorMessage = "Required")]
        public string Mol { get; set; }

        public bool IsDeleted { get; set; }
    }
}
