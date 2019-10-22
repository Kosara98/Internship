using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace FurnitureShop
{
    public abstract class Connection : Queries
    {
        protected string sqlConnection = ConfigurationManager.ConnectionStrings["FurnitureConnection"].ConnectionString;

        public virtual void ExecuteQuery(Dictionary<string, object> parameters, string query)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                foreach (var item in parameters)
                    command.Parameters.AddWithValue(item.Key, item.Value ?? SqlString.Null);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
