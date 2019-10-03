using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FurnitureShop
{
    public class ProductConnection
    {
        string query;
        string sqlConnection = "Data Source = LAPTOP-59C4S0U9; Initial Catalog = Furniture; Integrated Security = True";

        public void Insert(string name, string description, double weight, string barcode, double price)
        {
            if (description == null)
                query = "insert into Products values ('" + name + "', null," + weight + ", '" + barcode + "', " + price + ")";
            else
                query = $"insert into Products values ('" + name + "','" + description + "'," + weight + ", '" + barcode + "', " + price + ")";

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
        }

        public List<string> FillComboBox()
        {
            List<string> result = new List<string>();
            query = "select Name from Products";

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    result.Add(name);
                }
            }
            return result;
        }

        public DataTable SelectTable()
        {
            DataTable table = new DataTable();
            query = "select Name, Description, Weight, Barcode, Price from Products";

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
