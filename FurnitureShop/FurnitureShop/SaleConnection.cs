using System;
using System.Data;
using System.Data.SqlClient;

namespace FurnitureShop
{
    public class SaleConnection
    {
        string sqlConnection = "Data Source = LAPTOP-59C4S0U9; Initial Catalog = Furniture; Integrated Security = True";
        string query;

        public void Insert(DateTime saleDate, string invoice, int quantity, int productId, int clientId)
        {
            int saleId;
            string priceQuery = "(select Price from Products where Id = " + productId + ")";
            
            //Insert for table Sales
            query = "insert into Sales values ('" + saleDate + "'," + clientId + ",'" + invoice + "')";
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
            query = "insert into ProductSales values (" + productId + "," + saleId + "," + quantity + "," + priceQuery + ")";
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
        }

        public DataTable SelectTable()
        {
            DataTable table = new DataTable();
            query = 
                " select s.Invoice, p.Name as Product, ps.Quantity, c.Name as Client, s.SaleDate, ps.TotalPrice from ProductSales ps join Sales s on ps.SaleId = s.Id join Products p on ps.ProductId = p.Id join Clients c on s.ClientId = c.Id order by s.SaleDate";

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
