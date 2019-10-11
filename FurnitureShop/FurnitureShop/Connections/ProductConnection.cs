using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace FurnitureShop
{
    public class ProductConnection
    {
        internal string sqlConnection = ConfigurationManager.ConnectionStrings["FurnitureConnection"].ConnectionString;

        public void Insert(string name, string description, double weight, string barcode, double price)
        {
            string query = $"insert into Products values (@name, @description, {weight}, @barcode, {price})";

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
            
                if (description != null)
                    command.Parameters.AddWithValue("@description", description);

                command.Parameters.AddWithValue("@barcode", barcode);
                command.Parameters.AddWithValue("@name", name);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Product> ShowAllProducts()
        {
            List<Product> products = new List<Product>();
            string query = "select Id, Name, Description, Barcode, Weight, Price from Products";

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product();
                        product.Id = (int)reader["Id"];
                        product.Name = (string)reader["Name"];
                        product.Barcode = (string)reader["Barcode"];
                        product.Weight = Convert.ToDouble(reader["Weight"]);
                        product.Price = Convert.ToDouble(reader["Price"]);

                        if (reader["Description"] != DBNull.Value)
                            product.Description = (string)reader["Description"];

                        products.Add(product);
                    }
                }
            }
            return products;
        }
    }
}
