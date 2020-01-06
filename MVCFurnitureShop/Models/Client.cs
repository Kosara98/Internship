using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFurnitureShop.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Bulstat { get; set; }

        public char RegisteredVat { get; set; }

        public string Mol { get; set; }
    }
}
