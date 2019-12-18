using FurnitureShopAdo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FurnitureShopAdo.DataAccess.Repositories
{
    public class SaleRepository : BaseRepository<Sale>
    {
        public override IEnumerable<Sale> GetAll()
        {
            List<Sale> sales = new List<Sale>();

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(Queries.showAllSalesQuery, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var sale = new Sale
                        {
                            Id = (int)reader["Id"],
                            SaleDate = (DateTime)reader["SaleDate"],
                            Invoice = (string)reader["Invoice"],
                            Product = (string)reader["Product"],
                            Quantity = (int)reader["Quantity"],
                            Client = (string)reader["Client"],
                            UnitPrice = (decimal)reader["UnitPrice"],
                            TotalPrice = (decimal)reader["TotalPrice"]
                        };
                        sales.Add(sale);
                    }
                }
            }
            return sales;
        }

        public override void Insert(Sale sale)
        {
            int saleId;

            //Insert for table Sales
            Dictionary<string, object> parametersInsert = new Dictionary<string, object>
            {
                { "@invoice", sale.Invoice },
                { "@clientName", sale.Client },
                { "@date", sale.SaleDate }
            };
            ExecuteQuery(parametersInsert, Queries.insertQuerySales);

            //Query for saleId
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(Queries.selectSaleIdQuery, connection))
            {
                command.Parameters.AddWithValue("@invoice", sale.Invoice);
                connection.Open();
                saleId = (int)command.ExecuteScalar();
            }

            //Insert for table ProductSales
            foreach (var item in sale.Products)
            {
                Dictionary<string, object> parametersProductSales = new Dictionary<string, object>
                {
                    { "@id", item.Key },
                    { "@saleId", saleId },
                    { "@quantity", item.Value }
                };
                ExecuteQuery(parametersProductSales, Queries.insertQueryProductSales);
            }
        }

        public override void Delete(Sale sale)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", sale.Id);
            ExecuteQuery(parameters, Queries.deleteSaleQuery);
        }

        public override void Update(Sale sale)
        {
            foreach (var item in sale.Products)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@productId", item.Key },
                    { "@saleId", sale.Id },
                    { "@quantity", item.Value }
                };
                ExecuteQuery(parameters, Queries.updateProductSalesQuery);
            }
        }
    }
}
