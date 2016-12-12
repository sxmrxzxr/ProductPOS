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
                                      "Data Source=C:/Users/telec/Documents/Visual Studio 2015/Projects/ProductPOS/ProductPOS/ProductDB.accdb;" +
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
            catch (OleDbException ex)
            {
                resultVal = -1;
                System.Windows.Forms.MessageBox.Show(ex.ToString());//throw ex;
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
            string selectStatement = "SELECT Type, ID, Desc, Price, Qty FROM Product WHERE ID = '" + id + "';";
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
                System.Windows.Forms.MessageBox.Show(ex.ToString());
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
            string selectStatement = "SELECT Product.Type, Procuct.ID, Product.Desc, Product.Price, Product.Qty, Media.ReleaseDate, Disk.NumDisks, Disk.Size, Disk.TypeDisk, Entertainment.RunTime, Movie.Director, Movie.Producer " + 
                                     "FROM (((Product INNER JOIN Media ON Product.ID = Media.ID) INNER JOIN Disk ON Media.ID = Disk.ID) INNER JOIN Entertainment ON Disk.ID = Entertainment.ID) INNER JOIN Movie ON Entertainment.ID = Movie.ID " + 
                                     "WHERE Product.ID = '" + id + "';";
            OleDbCommand selectCommand = new OleDbCommand(selectStatement, conn);

            try
            {
                conn.Open();
                OleDbDataReader dataReader = selectCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    m = new Movie(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetDouble(3), dataReader.GetInt32(4), dataReader.GetDateTime(5), dataReader.GetInt32(6), dataReader.GetInt32(7), dataReader.GetString(8), dataReader.GetTimeSpan(9), dataReader.GetString(10), dataReader.GetString(12));
                }
            }
            catch (OleDbException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                //throw ex;
            }
            finally
            {
                conn.Close();
            }

            return m;
        }

        public static Music SelectMusic(string id)
        {
            Music m = (Music)null;

            OleDbConnection conn = GetConnection();
            string selectStatement = "SELECT Product.Type, Procuct.ID, Product.Desc, Product.Price, Product.Qty, Media.ReleaseDate, Disk.NumDisks, Disk.Size, Disk.TypeDisk, Entertainment.RunTime, Music.Artist, Music.Genre, Music.Label " +
                                     "FROM (((Product INNER JOIN Media ON Product.ID = Media.ID) INNER JOIN Disk ON Media.ID = Disk.ID) INNER JOIN Entertainment ON Disk.ID = Entertainment.ID) INNER JOIN Music ON Entertainment.ID = Music.ID " +
                                     "WHERE Product.ID = '" + id + "';";
            OleDbCommand selectCommand = new OleDbCommand(selectStatement, conn);

            try
            {
                conn.Open();
                OleDbDataReader dataReader = selectCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    m = new Music(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetDouble(3), dataReader.GetInt32(4), dataReader.GetDateTime(5), dataReader.GetInt32(6), dataReader.GetInt32(7), dataReader.GetString(8), dataReader.GetTimeSpan(9), dataReader.GetString(10), dataReader.GetString(12), dataReader.GetString(13));
                }
            }
            catch (OleDbException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return m;
        }

        public static Software SelectSoftware(string id)
        {
            Software s = (Software) null;

            OleDbConnection conn = GetConnection();
            string selectStatement = "SELECT Product.Type, Procuct.ID, Product.Desc, Product.Price, Product.Qty, Media.ReleaseDate, Disk.NumDisks, Disk.Size, Disk.TypeDisk, Software.TypeSoft " +
                                     "FROM ((Product INNER JOIN Media ON Product.ID = Media.ID) INNER JOIN Disk ON Media.ID = Disk.ID) INNER JOIN Software ON Disk.ID = Software.ID " +
                                     "WHERE Product.ID = '" + id + "';";
            OleDbCommand selectCommand = new OleDbCommand(selectStatement, conn);

            try
            {
                conn.Open();
                OleDbDataReader dataReader = selectCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    s = new Software(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetDouble(3), dataReader.GetInt32(4), dataReader.GetDateTime(5), dataReader.GetInt32(6), dataReader.GetInt32(7), dataReader.GetString(8), dataReader.GetString(9));
                }
            }
            catch (OleDbException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return s;
        }

        public static Book SelectBook(string id)
        {
            Book b = (Book) null;

            OleDbConnection conn = GetConnection();
            string selectStatement = "SELECT Product.Type, Procuct.ID, Product.Desc, Product.Price, Product.Qty, Media.ReleaseDate, Book.Author, Book.NumPages, Book.Publisher " +
                                     "FROM (Product INNER JOIN Media ON Product.ID = Media.ID) INNER JOIN Book ON Media.ID = Book.ID " +
                                     "WHERE Product.ID = '" + id + "';";
            OleDbCommand selectCommand = new OleDbCommand(selectStatement, conn);

            try
            {
                conn.Open();
                OleDbDataReader dataReader = selectCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    b = new Book(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetDouble(3), dataReader.GetInt32(4), dataReader.GetDateTime(5), dataReader.GetString(6), dataReader.GetInt32(7), dataReader.GetString(8));
                }
            }
            catch (OleDbException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return b;
        }

        public static TShirt SelectTShirt(string id)
        {
            TShirt t = (TShirt)null;

            OleDbConnection conn = GetConnection();
            string selectStatement = "SELECT Product.Type, Procuct.ID, Product.Desc, Product.Price, Product.Qty, Apparel.Color, Apparel.Size, Apparel.Material, TShirt.Size " +
                                     "FROM (Product INNER JOIN Apparel ON Product.ID = Apparel.ID) INNER JOIN TShirt ON Apparel.ID = TShirt.ID " +
                                     "WHERE Product.ID = '" + id + "';";
            OleDbCommand selectCommand = new OleDbCommand(selectStatement, conn);

            try
            {
                conn.Open();
                OleDbDataReader dataReader = selectCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    t = new TShirt(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetDouble(3), dataReader.GetInt32(4), dataReader.GetString(5), dataReader.GetString(6), dataReader.GetString(7), dataReader.GetString(8));
                }
            }
            catch (OleDbException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return t;
        }

        public static DressShirt SelectDressShirt(string id)
        {
            DressShirt d = (DressShirt) null;

            OleDbConnection conn = GetConnection();
            string selectStatement = "SELECT Product.Type, Procuct.ID, Product.Desc, Product.Price, Product.Qty, Apparel.Color, Apparel.Size, Apparel.Material, DressShirt.Neck, DressShirt.Sleeve " +
                                     "FROM (Product INNER JOIN Apparel ON Product.ID = Apparel.ID) INNER JOIN DressShirt ON Apparel.ID = DressShirt.ID " +
                                     "WHERE Product.ID = '" + id + "';";
            OleDbCommand selectCommand = new OleDbCommand(selectStatement, conn);

            try
            {
                conn.Open();
                OleDbDataReader dataReader = selectCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    d = new DressShirt(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetDouble(3), dataReader.GetInt32(4), dataReader.GetString(5), dataReader.GetString(6), dataReader.GetString(7), dataReader.GetInt32(8), dataReader.GetInt32(9));
                }
            }
            catch (OleDbException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return d;
        }

        public static Pants SelectPants(string id)
        {
            Pants p = (Pants) null;

            OleDbConnection conn = GetConnection();
            string selectStatement = "SELECT Product.Type, Procuct.ID, Product.Desc, Product.Price, Product.Qty, Apparel.Color, Apparel.Size, Apparel.Material, Pants.Inseam, Pants.Waist " +
                                     "FROM (Product INNER JOIN Apparel ON Product.ID = Apparel.ID) INNER JOIN Pants ON Apparel.ID = Pants.ID " +
                                     "WHERE Product.ID = '" + id + "';";
            OleDbCommand selectCommand = new OleDbCommand(selectStatement, conn);

            try
            {
                conn.Open();
                OleDbDataReader dataReader = selectCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    p = new Pants(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetDouble(3), dataReader.GetInt32(4), dataReader.GetString(5), dataReader.GetString(6), dataReader.GetString(7), dataReader.GetInt32(8), dataReader.GetInt32(9));
                }
            }
            catch (OleDbException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return p;
        }
        
        public static Product[] SelectLikeDesc(string query)
        {
            Product[] p = (Product[]) null;

            OleDbConnection conn = ProductDB.GetConnection();
            string selectStatement = "SELECT Type, ID, Desc, Price, Qty " +
                                     "FROM Product " +
                                     "WHERE Desc LIKE '%" + query + "%'";
            OleDbCommand selectCommand = new OleDbCommand(selectStatement, conn);

            try
            {
                conn.Open();
                OleDbDataReader dataReader = selectCommand.ExecuteReader();
                p = new Product[dataReader.FieldCount];
                int i = 0;

                while (dataReader.Read())
                {
                    p[i] = new Product(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetDouble(3), dataReader.GetInt32(4));
                    i++;
                }
            }
            catch (OleDbException ex) 
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return p;
        }

        public static int UpdateProduct(string id, int qty)
        {
            string updateStatement = "UPDATE Product SET Qty = " + Convert.ToString(qty) + " WHERE ID = '" + id + "';";
            return ExeNonQuery(updateStatement);
        }

        public static int InsertLineItem(int tid, string pid, int qty, double price)
        {
            string insertString = "INSERT INTO LineItem (TransID, ProductID, Qty, Price) VALUES (" + Convert.ToString(tid) + ", " + pid + ", " + Convert.ToString(qty) + ", " + Convert.ToString(price) + ");";
            return ExeNonQuery(insertString);
        }

        public static int InsertTrans(double subtotal, double tax, double total)
        {
            string insertString = "INSERT INTO Trans (Subtotal, Tax, Total) VALUES (" + Convert.ToString(subtotal) + ", " + Convert.ToString(tax) + ", " + Convert.ToString(total) + ");";
            return ExeNonQuery(insertString);
        }

        public static int SelectMaxTrans()
        {
            int num1 = 0;
            OleDbConnection conn = GetConnection();
            string selectStatement = "SELECT MAX(ID) FROM Trans;";
            OleDbCommand selectCommand = new OleDbCommand(selectStatement, conn);

            try
            {
                conn.Open();
                OleDbDataReader dataReader = selectCommand.ExecuteReader();
                if (dataReader.Read())
                    num1 = dataReader.GetInt32(0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                num1 = -1;
            }
            finally
            {
                conn.Close();
            }
            return num1;
        }
    }
}
