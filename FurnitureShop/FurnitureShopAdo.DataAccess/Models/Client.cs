using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureShopAdo.DataAccess
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Bulstat { get; set; }
        public char RegisteredVat { get; set; }
        public string Mol { get; set; }
    }
}
