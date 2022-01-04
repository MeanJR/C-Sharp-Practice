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
using System.Windows.Shapes;

namespace BookStoreApplication
{
    /// <summary>
    /// Interaction logic for AddBooks.xaml
    /// </summary>
    public partial class AddBooks : Window
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            if(titleName.Text != "" && priceBook.Text != "")
            {
                double price = double.Parse(priceBook.Text);
                InsertDataTable insert = new InsertDataTable();
                insert.InsertBooks(titleName.Text, description.Text, price);

                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Please Insert Title and Price");
            }



        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            StaffMenu staff = new StaffMenu();
            this.Close();

            staff.Show();
        }
    }
}
