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

        public void Insert(DateTime saleDate, string invoice, int clientId, Dictionary<int, int> Products)
        {
            int saleId;
            string date = saleDate.Day + "-" + saleDate.Month + "-" + saleDate.Year;

            //Insert for table Sales
            query = "insert into Sales values ('" + date + "'," + clientId + ",'" + invoice + "')";
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }

            //Query for saleId
            query = "select Id from Sales where Invoice = '" + invoice + "'";
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                saleId = (int)command.ExecuteScalar();
            }

            //Insert for table ProductSales
            foreach (KeyValuePair<int,int> item in Products)
            {
                string priceQuery = "(select Price from Products where Id = " + (item.Key + 1) + ")";
                query = "insert into ProductSales values (" + (item.Key + 1) + "," + saleId + "," + item.Value + "," + priceQuery + ")";

                using (SqlConnection connection = new SqlConnection(sqlConnection))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                }
            }
        }

        public DataTable SelectTable()
        {
            DataTable table = new DataTable();
            query =
                " select s.SaleDate, s.Invoice, p.Name as Product, ps.Quantity, c.Name as Client, ps.TotalPrice from ProductSales ps join Sales s on ps.SaleId = s.Id join Products p on ps.ProductId = p.Id join Clients c on s.ClientId = c.Id order by s.SaleDate desc";

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(table);
            }

            return table;
        }
    }
}
