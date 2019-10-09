using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace FurnitureShop
{
    public class ProductConnection
    {
        string query;
        string sqlConnection = ConfigurationManager.ConnectionStrings["FurnitureConnection"].ConnectionString;

        public void Insert(string name, string description, double weight, string barcode, double price)
        {
            query = $"insert into Products values (@name, @description, {weight}, @barcode, {price})";

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
            
                if (description != null)
                    command.Parameters.AddWithValue("@description", description);

                command.Parameters.AddWithValue("@barcode", barcode);
                command.Parameters.AddWithValue("@name", name);

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

        public List<Product> SelectTable()
        {
            List<Product> products = new List<Product>();
            query = "select Name, Description, Barcode, Weight, Price from Products";

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product();
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
