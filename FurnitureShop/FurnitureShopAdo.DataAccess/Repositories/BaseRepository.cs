using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FurnitureShopAdo.DataAccess.Repositories
{
    public abstract class BaseRepository<T>
    {
        protected string sqlConnection = "Data Source = LAPTOP-59C4S0U9; Initial Catalog = Furniture; Integrated Security = True";
        //ConfigurationManager.ConnectionStrings["FurnitureConnection"].ConnectionString;

        public abstract IEnumerable<T> GetAll();
        public abstract void Insert(T value);
        public abstract void Delete(T value);
        public abstract void Update(T value);

        public virtual void ExecuteQuery(Dictionary<string, object> parameters, string query)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                foreach (var item in parameters)
                    command.Parameters.AddWithValue(item.Key, item.Value ?? DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
