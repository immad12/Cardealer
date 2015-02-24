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
using Domain.Vehicle;

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

            CarDataGrid.ItemsSource = Cardealer.Instance.GetListOfCars();
            TruckDataGrid.ItemsSource = Cardealer.Instance.GetListOfTrucks();
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
        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new AddCarWindow();
            newWindow.Show();
        }

          private void UpdateCarButton_Click(object sender, RoutedEventArgs e)
        {
            CarDataGrid.Items.Refresh();
            TruckDataGrid.Items.Refresh();
        }
        #endregion

        
        private void CarDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var newWindow = new AddCarWindow();
            newWindow.Show();
            newWindow.SaveCarButton.Content = "OK";
            newWindow.CarModel.IsReadOnly = true;
            newWindow.CarColor.IsReadOnly = true;
            newWindow.CarSalePrice.IsReadOnly = true;
            newWindow.CarRentPrice.IsReadOnly = true;

            newWindow.CarRadioButton.IsChecked = true;
            var row_data = (Vehicle)CarDataGrid.SelectedItem;
            newWindow.CarModel.Text = row_data.Model;
            newWindow.CarColor.Text = row_data.Color;
            newWindow.CarSalePrice.Text = row_data.SalesPrice + "";
            newWindow.CarRentPrice.Text = row_data.RentPrice + "";
        }

        private void TruckDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var newWindow = new AddCarWindow();
            newWindow.Show();
            newWindow.SaveCarButton.Content = "OK";
            newWindow.CarModel.IsReadOnly = true;
            newWindow.CarColor.IsReadOnly = true;
            newWindow.CarSalePrice.IsReadOnly = true;
            newWindow.CarRentPrice.IsReadOnly = true;

            newWindow.TruckRadioButton.IsChecked = true;
            var row_data = (Vehicle)TruckDataGrid.SelectedItem;
            newWindow.CarModel.Text = row_data.Model;
            newWindow.CarColor.Text = row_data.Color;
            newWindow.CarSalePrice.Text = row_data.SalesPrice + "";
            newWindow.CarRentPrice.Text = row_data.RentPrice + "";
        }
    }
}
