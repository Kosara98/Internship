using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace FurnitureShop
{
    public abstract class Connection
    {
        protected string sqlConnection = ConfigurationManager.ConnectionStrings["FurnitureConnection"].ConnectionString;

        public void ExecuteQuery(Dictionary<string, object> parameters, string query)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                foreach (KeyValuePair<string, object> item in parameters)
                    command.Parameters.AddWithValue(item.Key, item.Value);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
