using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCFurnitureShop.Migrations
{
    public partial class SalesAndProductSales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSales");

            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}
