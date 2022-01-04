using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApplication
{
    class BookData
    {
        private static List<string> Data;
        private static List<string> bookTitle;


        public static List<string> GetData()
        {
            Data = new List<string>();
  
            using (SqliteConnection db = new SqliteConnection("Filename=bookStore.db"))
            {
                db.Open();

                string commandText = "SELECT ISBN, Title, Price From Books";

                SqliteCommand queryData = new SqliteCommand(commandText, db);
                SqliteDataReader sqliteDataReader = queryData.ExecuteReader();

                while (sqliteDataReader.Read())
                {
                    Data.Add(sqliteDataReader.GetString(0));
                   
                }

                db.Close();

                return Data;
            }

        }

        
        public static List<string> GetBookTitle()
        {
            bookTitle = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=bookStore.db"))
            {
                db.Open();

                string commandText = "SELECT Title From Books";

                SqliteCommand queryData = new SqliteCommand(commandText, db);
                SqliteDataReader sqliteDataReader = queryData.ExecuteReader();

                while (sqliteDataReader.Read())
                {
                    bookTitle.Add(sqliteDataReader.GetString(0));
                }

                db.Close();

                return bookTitle;
            }
        }


        public static double SearchPrice(string titleName)
        {
            double price = 0.0;
            using (SqliteConnection db = new SqliteConnection("Filename=bookStore.db"))
            {
                db.Open();

                string commandText = "SELECT price From Books where Title = '"+titleName+"' ";

                SqliteCommand queryData = new SqliteCommand(commandText, db);
                SqliteDataReader sqliteDataReader = queryData.ExecuteReader();

                while (sqliteDataReader.Read())
                {
                    price = sqliteDataReader.GetDouble(0);
                }

                
                db.Close();

                
            }

            return price;
        }

       
        
    }
}
