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

            //Initialize data for the grids
            PrivateDataGrid.ItemsSource = Cardealer.Instance.GetListOfPrivateCustomers();
            BusinessDataGrid.ItemsSource = Cardealer.Instance.GetListOfBusinessCustomers();
            CarDataGrid.ItemsSource = Cardealer.Instance.GetListOfCars();
            TruckDataGrid.ItemsSource = Cardealer.Instance.GetListOfTrucks();
        }

        #region Eventhandlers for Customers
        private void PrivateAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new AddPrivateCustomerWindow();
            newWindow.Show();
        }

        private void BusinessAddCustomer_Click_1(object sender, RoutedEventArgs e)
        {
            var newWindow = new AddBusinessCustomerWindow();
            newWindow.Show();
        }

        //Update the datagrids for private and business customers
        private void UpdateCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            PrivateDataGrid.Items.Refresh();
            BusinessDataGrid.Items.Refresh();
        }

        private void PrivateDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var newWindow = new AddPrivateCustomerWindow();
            newWindow.Show();
            newWindow.btnSave.Content = "OK";
            newWindow.btnSave.Margin = new Thickness(-30, 156, 0, 0);
            newWindow.btnClear.Visibility = Visibility.Hidden;
            newWindow.txtName.IsReadOnly = true;
            newWindow.txtAddress.IsReadOnly = true;
            newWindow.txtPhone.IsReadOnly = true;
            newWindow.txtBirthday.IsReadOnly = true;

            var row_data = (Private)PrivateDataGrid.SelectedItem;
            newWindow.txtName.Text = row_data.Name;
            newWindow.txtAddress.Text = row_data.Address;
            newWindow.txtPhone.Text = row_data.Phone;
            newWindow.txtBirthday.Text = row_data.Birthdate;
            if (row_data.Gender == "male")
                newWindow.radioBtnMale.IsChecked = true;
            else
                newWindow.radioBtnFemale.IsChecked = true;
        }

        private void BusinessDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var newWindow = new AddBusinessCustomerWindow();
            newWindow.Show();
            newWindow.btnSave.Content = "OK";
            newWindow.btnSave.Margin = new Thickness(-40, 137, 0, 0);
            newWindow.btnClear.Visibility = Visibility.Hidden;
            newWindow.txtCompanyName.IsReadOnly = true;
            newWindow.txtSerialNo.IsReadOnly = true;
            newWindow.txtAddress.IsReadOnly = true;
            newWindow.txtPhone.IsReadOnly = true;
            newWindow.txtEmail.IsReadOnly = true;

            var row_data = (Business)BusinessDataGrid.SelectedItem;
            newWindow.txtCompanyName.Text = row_data.CompanyName;
            newWindow.txtSerialNo.Text = row_data.SerialNumber;
            newWindow.txtAddress.Text = row_data.Address;
            newWindow.txtPhone.Text = row_data.Phone;
            newWindow.txtEmail.Text = row_data.Email;
        }
        #endregion

        #region Eventhandlers for Cars
        //Event for adding a new vehicle to the cardealer
        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new AddCarWindow();
            newWindow.Show();
        }

        //Update the datagrids for car and truck
        private void UpdateCarButton_Click(object sender, RoutedEventArgs e)
        {
            CarDataGrid.Items.Refresh();
            TruckDataGrid.Items.Refresh();
        }

        //View data about vehicle when double clicking on a row
        private void CarDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var newWindow = new AddCarWindow();
            newWindow.Show();
            newWindow.SaveCarButton.Content = "OK";
            newWindow.SaveCarButton.Margin = new Thickness(150, 275, 0, 0);
            newWindow.ClearCarButton.Visibility = Visibility.Hidden;
            //Change textboxes to not be editable
            newWindow.CarModel.IsReadOnly = true;
            newWindow.CarColor.IsReadOnly = true;
            newWindow.CarSalePrice.IsReadOnly = true;
            newWindow.CarRentPrice.IsReadOnly = true;

            //Get the information from the row
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
            newWindow.SaveCarButton.Margin = new Thickness(150, 275, 0, 0);
            newWindow.ClearCarButton.Visibility = Visibility.Hidden;
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
        #endregion
    }
}
