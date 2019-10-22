namespace FurnitureShop
{
    public abstract class Queries
    {
        // Sales table
        protected string deleteSaleQuery = "update Sales set IsDeleted = 1 where Id = @id";
        protected string showAllSalesQuery =
                                "select s.Id, s.SaleDate, s.Invoice, ps.ProductName as Product, ps.Quantity, s.ClientName as Client, ps.TotalPrice " +
                                "from ProductSales ps " +
                                "join Sales s on ps.SaleId = s.Id " +
                                "where s.IsDeleted = 0 " +
                                "order by s.SaleDate desc";
        protected string insertQueryProductSales = "insert into ProductSales " +
                                                " select Name, @saleId, @quantity, Price" +
                                                " from Products" +
                                                " where Id = @id";
        protected string selectSaleIdQuery = "select Id from Sales where Invoice = @invoice";
        protected string insertQuerySales = "insert into Sales values(@date, @clientName, @invoice, 0)";

        // Client table
        protected string insertClientQuery = "insert into Clients values (@name, @address, @bulstat, @vat, @mol, 0)";
        protected string showAllClietnsQuery = "select Id,Name, Address, Bulstat, RegisteredVat, Mol " +
                                            "from Clients " +
                                            "where IsDeleted = 0";
        protected string deleteClientQuery = "update Clients set IsDeleted = 1 where Id = @id";
        protected string updateClientQuery = "update Clients set Name = @name, Address = @address, Bulstat = @bulstat, RegisteredVat = @vat, Mol = @mol " +
                                        "where Id = @id";

        //Product table
        protected string insertProductQuery = "insert into Products values (@name, @description, @weight, @barcode, @price, 0)";
        protected string showAllProductsQuery = "select Id, Name, Description, Barcode, Weight, Price " +
                                    "from Products " +
                                    "where IsDeleted = 0";
        protected string deleteProductQuery = "update Products set IsDeleted = 1 where Id = @id";
        protected string updateProductQuery = "update Products set Name = @name, Description = @description, Weight = @weight, Barcode = @barcode, Price = @price " +
                "where Id = @id";
    }
}
