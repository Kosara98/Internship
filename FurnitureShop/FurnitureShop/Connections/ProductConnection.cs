using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace FurnitureShop
{
    public class ProductConnection : Connection<Product>
    {
        public override IEnumerable<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(Queries.showAllProductsQuery, connection))
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

        public override void Insert(Product product)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@barcode", product.Barcode);
            parameters.Add("@name", product.Name);
            parameters.Add("@weight", product.Weight);
            parameters.Add("@price", product.Price);
            parameters.Add("@description", product.Description);
            ExecuteQuery(parameters, Queries.insertProductQuery);
        }

        public override void Delete(Product product)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", product.Id);
            ExecuteQuery(parameters, Queries.deleteProductQuery);
        }

        public override void Update(Product product)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", product.Id);
            parameters.Add("@barcode", product.Barcode);
            parameters.Add("@name", product.Name);
            parameters.Add("@weight", product.Weight);
            parameters.Add("@price", product.Price);
            parameters.Add("@description", product.Description);
            ExecuteQuery(parameters, Queries.updateProductQuery);
        }
    }
}
