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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSale>().HasKey(ps => new { ps.SaleId, ps.ProductName });
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<ProductSale> ProductSales { get; set; }
    }
}
