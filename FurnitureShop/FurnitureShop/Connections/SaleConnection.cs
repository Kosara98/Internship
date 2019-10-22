using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FurnitureShop
{
    public class SaleConnection : Connection<Sale>
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
                        var sale = new Sale();
                        sale.Id = (int)reader["Id"];
                        sale.SaleDate = (DateTime)reader["SaleDate"];
                        sale.Invoice = (string)reader["Invoice"];
                        sale.Product = (string)reader["Product"];
                        sale.Quantity = (int)reader["Quantity"];
                        sale.Client = (string)reader["Client"];
                        sale.UnitPrice = (decimal)reader["UnitPrice"];
                        sale.TotalPrice = (decimal)reader["TotalPrice"];
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
            Dictionary<string, object> parametersInsert = new Dictionary<string, object>();
            parametersInsert.Add("@invoice", sale.Invoice);
            parametersInsert.Add("@clientName", sale.Client);
            parametersInsert.Add("@date", sale.SaleDate);
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
                Dictionary<string, object> parametersProductSales = new Dictionary<string, object>();
                parametersProductSales.Add("@id", item.Key);
                parametersProductSales.Add("@saleId", saleId);
                parametersProductSales.Add("@quantity", item.Value);
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
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@productId", item.Key);
                parameters.Add("@saleId", sale.Id);
                parameters.Add("@quantity", item.Value);
                ExecuteQuery(parameters, Queries.updateProductSalesQuery);
            }
        }
    }
}
