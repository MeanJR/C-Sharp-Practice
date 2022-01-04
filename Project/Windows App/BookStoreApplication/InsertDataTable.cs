using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApplication
{
    class InsertDataTable
    {
        // fill in Books table
        private string ISBN;
        private string title;
        private string description;
        private double price;

        // fill in Customer 
        private int customerId;
        private string customerName;
        private string customerAddress;
        private string customerEmail;

        // fill in Staff
        private int staffId;
        private string staffName;
        private string staffAddress;
        private string staffEmail;


        // fill in Login
        private string loginEmail;
        private string loginPassword;
        private string loginStatus;


        // Input data of Books table
        public void InsertBooks(string title, string description, double price)
        {
            this.ISBN = CreateISBN();
            this.title = title;
            this.description = description;
            this.price = price;
            AddData("Books");
        }



        // Input data of Customers table
        public void InsertCustomers(string customerName, string customerAddress, string customerEmail)
        {
            this.customerId = CreateID("customer");
            this.customerName = customerName;
            this.customerAddress = customerAddress;
            this.customerEmail = customerEmail;
            AddData("Customers");
        }

        // Input data of Admin table
        public void InsertStaff(string staffName, string staffAddress, string staffEmail)
        {
            this.staffId = CreateID("staff");
            this.staffName = staffName;
            this.staffAddress = staffAddress;
            this.staffEmail = staffEmail;
            AddData("Staffs");
        }

        public void InsertUserLogin(string loginEmail, string loginPassword, string loginStatus )
        {
            this.loginEmail = loginEmail;
            this.loginPassword = loginPassword;
            this.loginStatus = loginStatus;
            AddData("UserLogin");
        }




        //Add the new data
        public void AddData(string tableName)
        {
            using (SqliteConnection db =
            new SqliteConnection($"Filename=bookStore.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                //Books table
                if (tableName == "Books")
                {
                    // Use parameterized query to prevent SQL injection attacks
                    insertCommand.CommandText = "INSERT INTO Books VALUES (@ISBN, @title, @description, @price);";
                    insertCommand.Parameters.AddWithValue("@ISBN", ISBN);
                    insertCommand.Parameters.AddWithValue("@title", title);
                    insertCommand.Parameters.AddWithValue("@description", description);
                    insertCommand.Parameters.AddWithValue("@price", price);
                    insertCommand.ExecuteReader();
                }

                //Customers table
                if (tableName == "Customers")
                {
                    // Use parameterized query to prevent SQL injection attacks
                    insertCommand.CommandText = "INSERT INTO " + tableName + "VALUES (@customerId,@customerName, @customerAddress, @customerEmail);";
                    insertCommand.Parameters.AddWithValue("@customerId", customerId);
                    insertCommand.Parameters.AddWithValue("@customerName", customerName);
                    insertCommand.Parameters.AddWithValue("@customerAddress", customerAddress);
                    insertCommand.Parameters.AddWithValue("@customerEmail", customerEmail);
                    insertCommand.ExecuteReader();
                }

                //Admin table
                if (tableName == "Staffs")
                {
                    // Use parameterized query to prevent SQL injection attacks
                    insertCommand.CommandText = "INSERT INTO " + tableName + "VALUES (@staffID, @staffName, @staffAddress, @staffEmail);";
                    insertCommand.Parameters.AddWithValue("@staffID", staffId);
                    insertCommand.Parameters.AddWithValue("@staffName", staffName);
                    insertCommand.Parameters.AddWithValue("@staffAddress", staffAddress);
                    insertCommand.Parameters.AddWithValue("@staffEmail", staffEmail);
                    insertCommand.ExecuteReader();
                }


                if (tableName == "UserLogin")
                {
                    // Use parameterized query to prevent SQL injection attacks
                    insertCommand.CommandText = "INSERT INTO " + tableName + "VALUES (@email, @password, @status);";
                    insertCommand.Parameters.AddWithValue("@email", loginEmail);
                    insertCommand.Parameters.AddWithValue("@password", loginPassword);
                    insertCommand.Parameters.AddWithValue("@status", loginStatus);
                    insertCommand.ExecuteReader();
                }

                db.Close();
            }
        }

        private string QueryID(string status)
        {
            string queryID = "";

            using (SqliteConnection db = new SqliteConnection("Filename=bookStore.db"))
            {
                db.Open();

                string commandText = (status == "staff") ? "SELECT Staffs_Id From Staffs"
                                                         : "SELECT Customers_Id From Customers";

                SqliteCommand queryData = new SqliteCommand(commandText, db);
                SqliteDataReader sqliteDataReader = queryData.ExecuteReader();

                while (sqliteDataReader.Read())
                {
                    queryID = sqliteDataReader.GetString(0);
                }

                db.Close();           
            }
            return queryID;
        }



        private string CreateISBN()
        {
            Random RandomNumber = new Random();
            int num1 = RandomNumber.Next(0, 9);
            int num2 = RandomNumber.Next(0, 9);
            int num3 = RandomNumber.Next(0, 9);
            int num4 = RandomNumber.Next(0, 9);
            int num5 = RandomNumber.Next(0, 9);
            int num6 = RandomNumber.Next(0, 9);
            string CreateNumber0 = num1.ToString() + num2.ToString() + num3.ToString();
            string CreateNumber1 = num4.ToString() + num5.ToString() + num6.ToString();
            string isbn = "974-" + CreateNumber0 + "-" + CreateNumber1 + "-" + num3;
            return isbn;
        }

        private int CreateID(string status)
        {
            string checkId = QueryID(status);
            int numId = 0;
            if(checkId != "")
            {
                numId = int.Parse(checkId);
                numId++;
            }
            else
            {
                numId = 6400001;
            }

            return numId;
        }




    }
}
