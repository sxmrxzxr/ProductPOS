﻿using System;
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


        }
    }
}
