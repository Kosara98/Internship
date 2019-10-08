using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FurnitureShop
{
    public class ProductConnection
    {
        string query;
        string sqlConnection = ConfigurationManager.ConnectionStrings["FurnitureConnection"].ConnectionString;

        public void Insert(string name, string description, double weight, string barcode, double price)
        {
            if (description == null)
                query = "insert into Products values (@name, null," + weight + ", @barcode, " + price + ")";
            else
                query = "insert into Products values (@name, @description, " + weight + ", @barcode, " + price + ")";

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlParameter sqlParameterName = new SqlParameter();
                sqlParameterName.ParameterName = "@name";
                sqlParameterName.Value = name;

                if (description != null)
                {
                    SqlParameter sqlParameterDescription = new SqlParameter();
                    sqlParameterDescription.ParameterName = "@description";
                    sqlParameterDescription.Value = description;

                    command.Parameters.Add(sqlParameterDescription);
                }

                SqlParameter sqlParameterBarcode = new SqlParameter();
                sqlParameterBarcode.ParameterName = "@barcode";
                sqlParameterBarcode.Value = barcode;

                command.Parameters.Add(sqlParameterName);
                command.Parameters.Add(sqlParameterBarcode);

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

        public DataTable SelectTable()
        {
            DataTable table = new DataTable();
            query = "select Name, Description, Weight, Barcode, Price from Products";

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(table);
            }

            return table;
        }
    }
}
