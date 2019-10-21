using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace FurnitureShop
{
    public class ClientConnection : Connection
    {
        private string insertQuery = "insert into Clients values (@name, @address, @bulstat, @vat, @mol, 0)";
        private string showAllQuery = "select Id,Name, Address, Bulstat, RegisteredVat, Mol " +
                                "from Clients " +
                                "where IsDeleted = 0";
        private string deleteQuery = "update Clients set IsDeleted = 1 where Id = @id";
        private string updateQuery = "update Clients set Name = @name, Address = @address, Bulstat = @bulstat, RegisteredVat = @vat, Mol = @mol " +
                                "where Id = @id";

        public IEnumerable<Client> GetAll()
        {
            List<Client> clients = new List<Client>();

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(showAllQuery, connection))
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
            ExecuteQuery(parameters, insertQuery);
        }

        public void Delete(Client client)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", client.Id);
            ExecuteQuery(parameters, deleteQuery);
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
            ExecuteQuery(parameters, updateQuery);
        }
    }
}
