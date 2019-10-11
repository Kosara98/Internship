using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace FurnitureShop
{
    public class ClientConnection
    {
        internal string sqlConnection = ConfigurationManager.ConnectionStrings["FurnitureConnection"].ConnectionString;

        public void Insert(string name, string address, string bulstat, char registeredVat, string mol)
        {
            int vat = registeredVat == 'Y' ? 1 : 0;
            string query = $"insert into Clients values (@name, @address, @bulstat,'{vat}', @mol)";

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@bulstat", bulstat);
                    command.Parameters.AddWithValue("@mol", mol);
                    connection.Open();
                    command.ExecuteNonQuery();                    
                }
            }
        }

        public IEnumerable<Client> ShowAllClients()
        {
            List<Client> clients = new List<Client>();
            string query = "select Id,Name, Address, Bulstat, RegisteredVat, Mol from Clients";

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var client = new Client();
                        client.Id = (int)reader["Id"];
                        client.Name = (string)reader["Name"];
                        client.Address = (string)reader["Address"];
                        client.Bulstat = (string)reader["Bulstat"];
                        client.RegisteredVat = (bool)reader["RegisteredVat"] ? 'Y' : 'N';
                        client.Mol = (string)reader["Mol"];
                        clients.Add(client);
                    }
                }
            }
            return clients;
        }
    }
}
