using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApplication
{
    class Login
    {
        private static string passText;
        private static string statusText;
        private static bool passStatus = false;

        // Get password
    
        public static bool checkPass(string email , string passsWord)
        {
            
            using (SqliteConnection db = new SqliteConnection("Filename=bookStore.db"))
            {
                db.Open();

                string commandText = "SELECT Password FROM UserLogin Where Email = '"+email+"'";

                SqliteCommand queryData = new SqliteCommand(commandText, db);
                SqliteDataReader sqliteDataReader = queryData.ExecuteReader();

                while (sqliteDataReader.Read())
                {
                    passText = sqliteDataReader.GetString(0);

                }

                passStatus = (passText == passsWord) ? true : false;
                db.Close();
                return passStatus;
            }

                
               
        }


        // Get Status

        public static string checkStatus(string email)
        {

            using (SqliteConnection db = new SqliteConnection("Filename=bookStore.db"))
            {
                db.Open();
                string commandText = "SELECT Status From UserLogin Where Email = '" + email + "'";

                SqliteCommand queryData = new SqliteCommand(commandText, db);
                SqliteDataReader sqliteDataReader = queryData.ExecuteReader();

                while (sqliteDataReader.Read())
                {
                    statusText = sqliteDataReader.GetString(0);
                }

                db.Close();
            }

            return statusText;
        }


    }
}
