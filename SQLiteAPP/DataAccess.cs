using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteAPP
{
    class DataAccess
    {
        public async static void InitializeDatabase()
        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=sqliteSample.db"))
            {
                db.Open();
                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS MyTable (Primary_Key INTEGER PRIMARY KEY, " +
                    "Text_Entry NVARCHAR(2048) NULL)";

                String tableCommand2 = "CREATE TABLE IF NOT " +
                                       "EXISTS Customers " +
                                       "(Primary_Key INTEGER PRIMARY KEY, " +
                                       "First_Name NVARCHAR(40), " +
                                       "Last_Name NVARCHAR(40), " +
                                       "EMAIL NVARCHAR(40)"+
                                       ")";


                SqliteCommand createTable = new SqliteCommand(tableCommand2, db);
                createTable.ExecuteReader();
            }
        }

        //Add Data

        public static void AddData(string inputText)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=sqliteSample.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO Customers VALUES (NULL, @Entry);";
                insertCommand.Parameters.AddWithValue("@Entry", inputText);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }

        public static List<String> GetData()
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=sqliteSample.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT Text_Entry from Customers", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }
                db.Close();
            }
            return entries;
        }


    }
}
