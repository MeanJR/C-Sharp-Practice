using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApplication
{
    class DataBase
    {
        //for creating database
        public static void InitializeDatabase()
        {
            CreateBooks();
            CreateCustomers();
            CreateStaffs();
            UserLogin();

        }
        
        public static void CreateBooks()

        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=bookStore.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                                      "EXISTS Books (ISBN VARCHAR(20) PRIMARY KEY, " +
                                      "Title VARCHAR(40) UNIQUE, " +
                                      "Description VARCHAR(40), " +
                                      "Price DOUBLE )";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
                db.Close();
            }
        }


        public static void CreateCustomers()

        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=bookStore.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                            "EXISTS Custeomers (Customer_Id INTEGER PRIMARY KEY, " +
                                              "Customer_Name VARCHAR(40), " +
                                              "Address TEXT(200), " +
                                              "Email TEXT(100) UNIQUE ) "; 

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
                db.Close();
            }
        }



        public static void CreateStaffs()

        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=bookStore.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                            "EXISTS Staffs (Staffs_Id INTEGER PRIMARY KEY, " +
                                              "Staffs_Name VARCHAR(40), " +
                                              "Address TEXT(200), " +
                                              "Email TEXT(100) UNIQUE ) ";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
                db.Close();
            }
        }

        public static void UserLogin()

        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=bookStore.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                            "EXISTS UserLogin(Email TEXT(50) PRIMARY KEY, " +
                                              "Name VARCHAR(40), " +
                                              "Last_name VARCHAR(40), " +
                                              "Password VARCHAR(20), " +
                                              "Status VARCHAR(10) ) ";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
                db.Close();
            }
        }



    }
}
