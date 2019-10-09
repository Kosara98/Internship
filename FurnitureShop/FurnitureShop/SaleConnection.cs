using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace FurnitureShop
{
    public class SaleConnection
    {
        string sqlConnection = ConfigurationManager.ConnectionStrings["FurnitureConnection"].ConnectionString;
        string query;

        public void Insert(DateTime saleDate, string invoice, string clientName, Dictionary<string, int> Products)
        {
            int saleId;
            string date = $"{saleDate.Day}-{saleDate.Month}-{saleDate.Year}";

            //Insert for table Sales
            query = $"insert into Sales select '{date}',Id, @invoice from Clients where Name = @clientName";

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@invoice", invoice);
                    command.Parameters.AddWithValue("@clientName", clientName);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                }
            }

            //Query for saleId
            query = $"select Id from Sales where Invoice = @invoice";

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@invoice", invoice);
                    connection.Open();
                    saleId = (int)command.ExecuteScalar();
                }
            }

            //Insert for table ProductSales
            foreach (KeyValuePair<string,int> item in Products)
            {
                query = $"insert into ProductSales " +
                    $" select Id, {saleId}, {item.Value},Price" +
                    $" from Products" +
                    $" where Name = @productName";
                
                using (SqlConnection connection = new SqlConnection(sqlConnection))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@productName", item.Key);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                    }
                }
            }
        }

        public List<Sale> SelectTable()
        {
            List<Sale> sales = new List<Sale>();
            query =
                "select s.SaleDate, s.Invoice, p.Name as Product, ps.Quantity, c.Name as Client, ps.TotalPrice " +
                "from ProductSales ps " +
                "join Sales s on ps.SaleId = s.Id " +
                "join Products p on ps.ProductId = p.Id " +
                "join Clients c on s.ClientId = c.Id " +
                "order by s.SaleDate desc";

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var sale = new Sale();
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
    }
}
