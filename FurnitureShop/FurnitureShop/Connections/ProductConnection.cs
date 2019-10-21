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
                "where IsDeleted = 0";
        private string deleteQuery = "update Products set IsDeleted = 1 where Id = @id";
        private string updateQuery = "update Products set Name = @name, Description = @description, Weight = @weight, Barcode = @barcode, Price = @price " +
                "where Id = @id";

        public IEnumerable<Product> GetAll()
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

        public void Insert(Product product)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@barcode", product.Barcode);
            parameters.Add("@name", product.Name);
            parameters.Add("@weight", product.Weight);
            parameters.Add("@price", product.Price);

            if (product.Description != null)
                parameters.Add("@description", product.Description);
            else
                parameters.Add("@description", "");

            ExecuteQuery(parameters, insertQuery);
        }

        public void Delete(Product product)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", product.Id);
            ExecuteQuery(parameters, deleteQuery);
        }

        public void Update(Product product)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", product.Id);
            parameters.Add("@barcode", product.Barcode);
            parameters.Add("@name", product.Name);
            parameters.Add("@weight", product.Weight);
            parameters.Add("@price", product.Price);

            if (product.Description != null)
                parameters.Add("@description", product.Description);
            else
                parameters.Add("@description", "");

            ExecuteQuery(parameters, updateQuery);
        }
    }
}
