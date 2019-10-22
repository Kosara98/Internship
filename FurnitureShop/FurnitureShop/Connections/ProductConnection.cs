using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace FurnitureShop
{
    public class ProductConnection : Connection
    {
        public IEnumerable<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(showAllProductsQuery, connection))
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
            parameters.Add("@description", product.Description);
            ExecuteQuery(parameters, insertProductQuery);
        }

        public void Delete(Product product)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", product.Id);
            ExecuteQuery(parameters, deleteProductQuery);
        }

        public void Update(Product product)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", product.Id);
            parameters.Add("@barcode", product.Barcode);
            parameters.Add("@name", product.Name);
            parameters.Add("@weight", product.Weight);
            parameters.Add("@price", product.Price);
            parameters.Add("@description", product.Description);
            ExecuteQuery(parameters, updateProductQuery);
        }
    }
}
