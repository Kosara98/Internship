using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace FurnitureShop
{
    public class SaleConnection : Connection
    {
        public IEnumerable<Sale> GetAll()
        {
            List<Sale> sales = new List<Sale>();

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(showAllSalesQuery, connection))
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
                        sale.TotalPrice = (decimal)reader["TotalPrice"];
                        sales.Add(sale);
                    }
                }
            }
            return sales;
        }

        public void Insert(Sale sale)
        {
            int saleId;

            //Insert for table Sales
            Dictionary<string, object> parametersInsert = new Dictionary<string, object>();
            parametersInsert.Add("@invoice", sale.Invoice);
            parametersInsert.Add("@clientName", sale.Client);
            parametersInsert.Add("@date", sale.SaleDate);
            ExecuteQuery(parametersInsert, insertQuerySales);

            //Query for saleId
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(selectSaleIdQuery, connection))
            {
                command.Parameters.AddWithValue("@invoice", sale.Invoice);
                connection.Open();
                saleId = (int)command.ExecuteScalar();
            }

            //Insert for table ProductSales
            foreach (KeyValuePair<int,int> item in sale.Products)
            {
                Dictionary<string, object> parametersProductSales = new Dictionary<string, object>();
                parametersProductSales.Add("@id", item.Key);
                parametersProductSales.Add("@saleId", saleId);
                parametersProductSales.Add("@quantity", item.Value);
                ExecuteQuery(parametersProductSales, insertQueryProductSales);
            }
        }

        public void Delete(Sale sale)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", sale.Id);
            ExecuteQuery(parameters, deleteSaleQuery);
        }
    }
}
