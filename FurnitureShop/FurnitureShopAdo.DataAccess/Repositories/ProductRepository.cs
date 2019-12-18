using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using FurnitureShop.Core.Models;
using FurnitureShop.Core.Repositories;

namespace FurnitureShopAdo.DataAccess.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
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
                        Product product = new Product
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Barcode = (string)reader["Barcode"],
                            Weight = (decimal)reader["Weight"],
                            Price = (decimal)reader["Price"]
                        };

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
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@barcode", product.Barcode },
                { "@name", product.Name },
                { "@weight", product.Weight },
                { "@price", product.Price },
                { "@description", product.Description }
            };
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
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@id", product.Id },
                { "@barcode", product.Barcode },
                { "@name", product.Name },
                { "@weight", product.Weight },
                { "@price", product.Price },
                { "@description", product.Description }
            };
            ExecuteQuery(parameters, Queries.updateProductQuery);
        }
    }
}
