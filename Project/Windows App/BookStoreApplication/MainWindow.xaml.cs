using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookStoreApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataBase.InitializeDatabase();
            
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
           
            bool passCheck = Login.checkPass(emailText.Text, passText.Password);
            string statusCheck = Login.checkStatus(emailText.Text);

            if(emailText.Text != "" && passText.Password != "")
            {
                if(passCheck == true )
                {

                    MessageBox.Show("Login Success");

                    if (statusCheck == "staff")
                    {
                        
                        StaffMenu staff = new StaffMenu();
                        this.Close();
                        staff.Show();

                    }
                    else
                    {
                        OrderMenu order = new OrderMenu();
                        this.Close();
                        order.Show();
                    }


                }
                else
                {
                    MessageBox.Show("Login Fail");
                }
                
                
            }
            else
            {
                MessageBox.Show("Please Input your email and password");
            }

            

        }

        private void SignUP_Click(object sender, RoutedEventArgs e)
        {
            string status = "customer";
            Register register = new Register(status);
            register.Show();


        }
    }
}
