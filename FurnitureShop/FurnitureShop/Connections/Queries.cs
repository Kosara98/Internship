namespace FurnitureShop
{
    public static class Queries
    {
        // Sales table
        internal static string deleteSaleQuery = "update Sales set IsDeleted = 1 where Id = @id";
        internal static string showAllSalesQuery =
                                "select s.Id, s.SaleDate, s.Invoice, ps.ProductName as Product, ps.Quantity, s.ClientName as Client, ps.Price as UnitPrice, ps.TotalPrice " +
                                "from ProductSales ps " +
                                "join Sales s on ps.SaleId = s.Id " +
                                "where s.IsDeleted = 0 " +
                                "order by s.SaleDate desc";
        internal static string insertQueryProductSales = "insert into ProductSales " +
                                                " select Name, @saleId, @quantity, Price" +
                                                " from Products" +
                                                " where Id = @id";
        internal static string selectSaleIdQuery = "select Id from Sales where Invoice = @invoice";
        internal static string insertQuerySales = "insert into Sales values(@date, @clientName, @invoice, 0)";
        internal static string updateProductSalesQuery = "update ProductSales " +
                                "set ProductName = p.Name, Quantity = @quantity, Price = p.Price " +
                                "from ( select Name, Price " +
                                    "from Products " +
                                    "where Id = @produdctId) p " +
                                "where SaleId = @saleId ";

        // Client table
        internal static string insertClientQuery = "insert into Clients values (@name, @address, @bulstat, @vat, @mol, 0)";
        internal static string showAllClietnsQuery = "select Id,Name, Address, Bulstat, RegisteredVat, Mol " +
                                            "from Clients " +
                                            "where IsDeleted = 0";
        internal static string deleteClientQuery = "update Clients set IsDeleted = 1 where Id = @id";
        internal static string updateClientQuery = "update Clients set Name = @name, Address = @address, Bulstat = @bulstat, RegisteredVat = @vat, Mol = @mol " +
                                        "where Id = @id";

        //Product table
        internal static string insertProductQuery = "insert into Products values (@name, @description, @weight, @barcode, @price, 0)";
        internal static string showAllProductsQuery = "select Id, Name, Description, Barcode, Weight, Price " +
                                    "from Products " +
                                    "where IsDeleted = 0";
        internal static string deleteProductQuery = "update Products set IsDeleted = 1 where Id = @id";
        internal static string updateProductQuery = "update Products set Name = @name, Description = @description, Weight = @weight, Barcode = @barcode, Price = @price " +
                "where Id = @id";
    }
}
