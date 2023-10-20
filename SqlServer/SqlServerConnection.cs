using System.Data.SqlClient;

namespace BookShop.SqlServar        
{
    public class SqlServerConnection
    {
        static string connectionstring= "Data Source=.;Initial Catalog=bookshop; Integrated Security=True";
        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            return connection;
        }
    }
}
