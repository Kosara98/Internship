using System.Data;
using System.Data.SqlClient;

namespace FurnitureShop
{
    public class Products
    {
        string query;
        SqlConnection sqlConnection = new SqlConnection
                ("Data Source = LAPTOP-59C4S0U9; Initial Catalog = Furniture; Integrated Security = True");
        
        public string Name { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public string Barcode { get; set; }
        public double Price { get; set; }

        public void Insert()
        {
            if (Description == null)
                query = "insert into Products values ('" + Name + "', null," + Weight + ", '" + Barcode + "', " + Price + ")";
            else
                query = "insert into Products values ('" + Name + "','" + Description + "'," + Weight + ", '" + Barcode + "', " + Price + ")";
            
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            sqlConnection.Close();
        }    
    }
}
