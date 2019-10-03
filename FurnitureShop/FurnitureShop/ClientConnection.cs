using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FurnitureShop
{
    public class ClientConnection
    {
        string sqlConnection = "Data Source = LAPTOP-59C4S0U9; Initial Catalog = Furniture; Integrated Security = True";
        string query;

        public void Insert(string name, string address, string bulstat, char registeredVat, string mol)
        {
            int vat = registeredVat == 'Y' ? 1 : 0;

            query = "insert into Clients values ('" + name + "','" + address + "','" + bulstat + "', '" + vat + "', '" + mol + "')";

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
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
