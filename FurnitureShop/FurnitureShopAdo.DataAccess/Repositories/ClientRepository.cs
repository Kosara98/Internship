using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using FurnitureShopAdo.DataAccess.Repositories;
using FurnitureShop.Core.Models;
using FurnitureShop.Core.Repositories;

namespace FurnitureShopAdo.DataAccess
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public override IEnumerable<Client> GetAll()
        {
            List<Client> clients = new List<Client>();

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(Queries.showAllClietnsQuery, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var client = new Client
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Address = (string)reader["Address"],
                            Bulstat = (string)reader["Bulstat"],
                            RegisteredVat = (bool)reader["RegisteredVat"] ? 'Y' : 'N',
                            Mol = (string)reader["Mol"]
                        };
                        clients.Add(client);
                    }
                }
            }
            return clients;
        }

        public override void Insert(Client client)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@name", client.Name },
                { "@address", client.Address },
                { "@bulstat", client.Bulstat },
                { "@vat", client.RegisteredVat == 'Y' ? 1 : 0 },
                { "@mol", client.Mol }
            };
            ExecuteQuery(parameters, Queries.insertClientQuery);
        }

        public override void Delete(Client client)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", client.Id);
            ExecuteQuery(parameters, Queries.deleteClientQuery);
        }

        public override void Update(Client client)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@id", client.Id },
                { "@name", client.Name },
                { "@address", client.Address },
                { "@bulstat", client.Bulstat },
                { "@vat", client.RegisteredVat == 'Y' ? 1 : 0 },
                { "@mol", client.Mol }
            };
            ExecuteQuery(parameters, Queries.updateClientQuery);
        }
    }
}
