using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace FurnitureShop
{
    public class ProductConnection : Connection
    {
        private string insertQuery = "insert into Products values (@name, @description, @weight, @barcode, @price, 0)";
        private string showAllQuery = "select Id, Name, Description, Barcode, Weight, Price " +
                "from Products " +
                "where isDeleted = 0";
        private string deleteQuery = "update Products set isDeleted = 1 where Barcode = @barcode";
        private string updateQuery = "update Products set Name = @name, Description = @description, Weight = @weight, Barcode = @barcode, Price = @price " +
                "where Id = @id";

        public void Insert(string name, string description, decimal weight, string barcode, decimal price)
        {
            if (description == null)
                insertQuery = "insert into Products values (@name, null, @weight, @barcode, @price, 0)";

            InsertOrUpdate(name, description, weight, barcode, price, insertQuery, -1);
        }

        public IEnumerable<Product> ShowAll()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(showAllQuery, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.Id = (int)reader["Id"];
                        product.Name = (string)reader["Name"];
                        product.Barcode = (string)reader["Barcode"];
                        product.Weight = (decimal)reader["Weight"];
                        product.Price = (decimal)reader["Price"];

                        if (reader["Description"] != DBNull.Value)
                            product.Description = (string)reader["Description"];

                        products.Add(product);
                    }
                }
            }
            return products;
        }

        public void Delete(string barcode)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@barcode", barcode);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(string name, string description, decimal weight, string barcode, decimal price, int id)
        {
            if (description == null)
                updateQuery = "update Products set Name = @name, Description = null, Weight = @weight, Barcode = @barcode, Price = @price " +
                "where Id = @id";

            InsertOrUpdate(name, description, weight, barcode, price, updateQuery, id);
        }

        private void InsertOrUpdate(string name, string description, decimal weight, string barcode, decimal price, string query, int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (description != null)
                    command.Parameters.AddWithValue("@description", description);

                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@barcode", barcode);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@weight", weight);
                command.Parameters.AddWithValue("@price", price);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
