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
                                "where isDeleted = 0";
        private string deleteQuery = "update Clients set isDeleted = 1 where Bulstat = @bulstat";
        private string updateQuery = "update Clients set Name = @name, Address = @address, Bulstat = @bulstat, RegisteredVat = @vat, Mol = @mol " +
                                "where Id = @id";

        public void Insert(string name, string address, string bulstat, char registeredVat, string mol)
        {
            InsertOrUpdate(name, address, bulstat, registeredVat, mol, updateQuery, -1);
        }

        public IEnumerable<Client> ShowAll()
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

        public void Delete(string bulstat)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@bulstat", bulstat);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(string name, string address, string bulstat, char registeredVat, string mol, int id)
        {
            InsertOrUpdate(name, address, bulstat, registeredVat, mol, updateQuery, id);
        }

        private void InsertOrUpdate(string name, string address, string bulstat, char registeredVat, string mol, string query, int id)
        {
            int vat = registeredVat == 'Y' ? 1 : 0;

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@bulstat", bulstat);
                command.Parameters.AddWithValue("@vat", vat);
                command.Parameters.AddWithValue("@mol", mol);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
