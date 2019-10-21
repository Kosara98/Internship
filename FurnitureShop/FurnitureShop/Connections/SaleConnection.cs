using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace FurnitureShop
{
    public class SaleConnection : Connection
    {
        private string insertQuerySales = "insert into Sales values(@date, @clientName, @invoice, 0)";
        private string selectSaleIdQuery = "select Id from Sales where Invoice = @invoice";
        private string insertQueryProductSales = "insert into ProductSales " +
                                                " select Name, @saleId, @quantity, Price" +
                                                " from Products" +
                                                " where Id = @id";
        private string showAllQuery =
                                "select s.Id, s.SaleDate, s.Invoice, ps.ProductName as Product, ps.Quantity, s.ClientName as Client, ps.TotalPrice " +
                                "from ProductSales ps " +
                                "join Sales s on ps.SaleId = s.Id " +
                                "where s.IsDeleted = 0 " +
                                "order by s.SaleDate desc";
        private string deleteQuery = "update Sales set IsDeleted = 1 where Id = @id";

        public IEnumerable<Sale> GetAll()
        {
            List<Sale> sales = new List<Sale>();

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(showAllQuery, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var sale = new Sale();
                        sale.Id = (int)reader["Id"];
                        sale.SaleDate = (DateTime)reader["SaleDate"];
                        sale.Invoice = (string)reader["Invoice"];
                        sale.Product = (string)reader["Product"];
                        sale.Quantity = (int)reader["Quantity"];
                        sale.Client = (string)reader["Client"];
                        sale.TotalPrice = (decimal)reader["TotalPrice"];
                        sales.Add(sale);
                    }
                }
            }
            return sales;
        }

        public void Insert(Sale sale)
        {
            int saleId;

            //Insert for table Sales
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@invoice", sale.Invoice);
            parameters.Add("@clientName", sale.Client);
            parameters.Add("@date", sale.SaleDate);
            ExecuteQuery(parameters, insertQuerySales);

            //Query for saleId
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(selectSaleIdQuery, connection))
            {
                command.Parameters.AddWithValue("@invoice", sale.Invoice);
                connection.Open();
                saleId = (int)command.ExecuteScalar();
            }

            //Insert for table ProductSales
            foreach (KeyValuePair<int,int> item in sale.Products)
            {
                using (SqlConnection connection = new SqlConnection(sqlConnection))
                using (SqlCommand command = new SqlCommand(insertQueryProductSales, connection))
                {
                    command.Parameters.AddWithValue("@id", item.Key);
                    command.Parameters.AddWithValue("@saleId", saleId);
                    command.Parameters.AddWithValue("@quantity", item.Value);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                }
            }
        }

        public void Delete(Sale sale)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", sale.Id);
            ExecuteQuery(parameters, deleteQuery);
        }
    }
}
