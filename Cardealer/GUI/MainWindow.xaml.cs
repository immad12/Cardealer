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
using Domain;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //CarDataGrid.ItemsSource = List of cars
        }

        #region Eventhandlers for Private Customers
        private void PrivateFindCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PrivateAddCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PrivateEditCustomer_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Eventhandlers for Business Customers
        private void BusinessFindCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BusinessAddCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BusinessEditCustomer_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Eventhandlers for Cars
        private void FindCar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new AddCarWindow();
            newWindow.Show();
        }

        private void EditCar_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
    }
}
