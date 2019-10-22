using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace FurnitureShop
{
    public class ClientConnection : Connection
    {
        public IEnumerable<Client> GetAll()
        {
            List<Client> clients = new List<Client>();

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(showAllClietnsQuery, connection))
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
        
        public void Insert(Client client)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", client.Name);
            parameters.Add("@address", client.Address);
            parameters.Add("@bulstat", client.Bulstat);
            parameters.Add("@vat", client.RegisteredVat == 'Y' ? 1 : 0);
            parameters.Add("@mol", client.Mol);
            ExecuteQuery(parameters, insertClientQuery);
        }

        public void Delete(Client client)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", client.Id);
            ExecuteQuery(parameters, deleteClientQuery);
        }

        public void Update(Client client)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", client.Id);
            parameters.Add("@name", client.Name);
            parameters.Add("@address", client.Address);
            parameters.Add("@bulstat", client.Bulstat);
            parameters.Add("@vat", client.RegisteredVat == 'Y' ? 1 : 0);
            parameters.Add("@mol", client.Mol);
            ExecuteQuery(parameters, updateClientQuery);
        }
    }
}
