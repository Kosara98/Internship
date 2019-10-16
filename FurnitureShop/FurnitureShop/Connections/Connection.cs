using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace FurnitureShop
{
    public abstract class Connection
    {
         protected string sqlConnection = ConfigurationManager.ConnectionStrings["FurnitureConnection"].ConnectionString;
    }
}
