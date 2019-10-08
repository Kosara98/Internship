using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FurnitureShop
{
    public class ClientConnection
    {
        string sqlConnection = ConfigurationManager.ConnectionStrings["FurnitureConnection"].ConnectionString;
        string query;

        public void Insert(string name, string address, string bulstat, char registeredVat, string mol)
        {
            int vat = registeredVat == 'Y' ? 1 : 0;

            query = "insert into Clients values (@name, @address,'" + bulstat + "', '" + vat + "', @mol)";

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);

                SqlParameter sqlParameterName = new SqlParameter();
                sqlParameterName.ParameterName = "@name";
                sqlParameterName.Value = name;

                SqlParameter sqlParameterAddress = new SqlParameter();
                sqlParameterAddress.ParameterName = "@address";
                sqlParameterAddress.Value = address;

                SqlParameter sqlParameterMol = new SqlParameter();
                sqlParameterMol.ParameterName = "@mol";
                sqlParameterMol.Value = mol;

                command.Parameters.Add(sqlParameterName);
                command.Parameters.Add(sqlParameterAddress);
                command.Parameters.Add(sqlParameterMol);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
        }
        
        public List<string> FillComboBox()
        {
            List<string> result = new List<string>();
            query = "select Name from Clients";

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
            query = "select Name, Address, Bulstat, RegisteredVat, Mol from Clients";

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
