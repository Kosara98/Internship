using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCFurnitureShop.Models;

namespace MVCFurnitureShop.Data
{
    public class MVCFurnitureShopContext : DbContext
    {
        public MVCFurnitureShopContext(DbContextOptions<MVCFurnitureShopContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
