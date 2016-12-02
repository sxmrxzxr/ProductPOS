using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPOS
{
    public class ProductDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                      "Data Source=|DataDirectory|/ProductDB.accdb;" +
                                      "Persist Security Info=True";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        public void ExeNonQuery()
        {

        }
    }
}
