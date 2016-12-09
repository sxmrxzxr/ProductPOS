using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPOS
{
    public class ProductDB
    {
        public static OleDbConnection GetConnection()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                      "Data Source=|DataDirectory|/ProductDB.accdb;" +
                                      "Persist Security Info=True";
            OleDbConnection connection = new OleDbConnection(connectionString);
            return connection;
        }

        public static int ExeNonQuery(string sqlString)
        {
            int resultVal = 0;

            OleDbConnection connection = ProductDB.GetConnection();
            OleDbCommand command = new OleDbCommand(sqlString, connection);

            try
            {
                connection.Open();
                resultVal = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                resultVal = -1;
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return resultVal;
        }
        
        public static Product SelectProduct(string id)
        {
            Product p = (Product) null;

            OleDbConnection conn = GetConnection();
            string selectStatement = "SELECT ID, Desc, Price, Qty, Type FROM Product WHERE ID = '" + id + "';";
            OleDbCommand selectCommand = new OleDbCommand(selectStatement, conn);

            try
            {
                conn.Open();
                OleDbDataReader dataReader = selectCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    p = new Product(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetDouble(3), dataReader.GetInt32(4));
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return p;
        }

        public static Movie SelectMovie(string id)
        {
            Movie m = (Movie) null;

            OleDbConnection conn = GetConnection();
            string selectStatement = "SELECT ID, Desc, Price, Qty, Type, FROM Movie WHERE ID = '" + id + "';";
            OleDbCommand selectCommand = new OleDbCommand(selectStatement, conn);

            try
            {
                conn.Open();
                OleDbDataReader dataReader = selectCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    m = new Movie(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetDouble(3), dataReader.GetInt32(4));
                }
            }
        }
    }
}
