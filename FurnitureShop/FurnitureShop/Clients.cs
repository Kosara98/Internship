using System.Data.SqlClient;

namespace FurnitureShop
{
    public class Clients
    {
        SqlConnection sqlConnection = new SqlConnection
                ("Data Source = LAPTOP-59C4S0U9; Initial Catalog = Furniture; Integrated Security = True");

        public string Name { get; set; }
        public string Address { get; set; }
        public string Bulstat { get; set; }
        public char RegisteredVat { get; set; }
        public string Mol { get; set; }

        public void Insert()
        {
            int vat;

            if (RegisteredVat == 'Y')
                vat = 1;
            else
                vat = 0;

            string insertQuery = "insert into Clients values ('" + Name + "','" + Address + "','" + Bulstat + "', '" + vat + "', '" + Mol + "')";

            sqlConnection.Open();
            SqlCommand command = new SqlCommand(insertQuery, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            sqlConnection.Close();
        }
    }
}
