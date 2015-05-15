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
    /// Niels & Mette, Group 2
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        /* private Car selectedCar;
         private Truck selectedTruck;
         private Private selectedPrivate;
         private Business selectedBusiness; */

        public MainWindow()
        {
            InitializeComponent();

            //Initialize data for the grids
            CarDataGrid.ItemsSource = Cardealer.Instance.Cars;
            TruckDataGrid.ItemsSource = Cardealer.Instance.Trucks;
            PrivateDataGrid.ItemsSource = Cardealer.Instance.PrivateCustomers;
            BusinessDataGrid.ItemsSource = Cardealer.Instance.BusinessCustomers;

            //Initialize all comboboxes
            InitComboboxes();
        }

        private void InitComboboxes()
        {
            //Customer combobox
            comboBoxCustomer.Items.Add("---- Private ----");
            foreach (Private privateCustomer in Cardealer.Instance.PrivateCustomers)
            {
                comboBoxCustomer.Items.Add(privateCustomer.Name);
            }
            comboBoxCustomer.Items.Add("---- Business ----");
            foreach (Business businessCustomer in Cardealer.Instance.BusinessCustomers)
            {
                comboBoxCustomer.Items.Add(businessCustomer.CompanyName);
            }
            comboBoxCustomer.SelectedIndex = 0;

            //Vehicle combobox
            comboBoxVehicle.Items.Add("---- Cars ----");
            foreach (Car car in Cardealer.Instance.Cars)
            {
                comboBoxVehicle.Items.Add(car.Model);
            }

            comboBoxVehicle.Items.Add("---- Trucks ----");
            foreach (Truck truck in Cardealer.Instance.Trucks)
            {
                comboBoxVehicle.Items.Add(truck.Model);
            }
            comboBoxVehicle.SelectedIndex = 0;
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
            //PrivateDataGrid.Items.Refresh();
            //BusinessDataGrid.Items.Refresh();
            Cardealer.Instance.UpdateCustomers();
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
            var row_data = (Vehicles)CarDataGrid.SelectedItem;
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
            var row_data = (Vehicles)TruckDataGrid.SelectedItem;
            newWindow.CarModel.Text = row_data.Model;
            newWindow.CarColor.Text = row_data.Color;
            newWindow.CarSalePrice.Text = row_data.SalesPrice + "";
            newWindow.CarRentPrice.Text = row_data.RentPrice + "";
        }
        #endregion

        #region Eventhandlers for Leasing
        private void BtnLease_Click(object sender, RoutedEventArgs e)
        {
            Vehicles vehicle = null;
            Private privatCustomer = null;
            Business businessCustomer = null;

            if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtModel.Text)
              && !string.IsNullOrWhiteSpace(txtRentPeriod.Text) && !string.IsNullOrWhiteSpace(txtTotalPrice.Text))
            {
                #region Instantiate Vehicle and customer
                foreach (Private privateCust in Cardealer.Instance.PrivateCustomers)
                {
                    if (privateCust.Name == comboBoxCustomer.SelectedItem.ToString())
                    {
                        privatCustomer = privateCust;
                    }
                }
                foreach (Business businessCust in Cardealer.Instance.BusinessCustomers)
                {
                    if (businessCust.CompanyName == comboBoxCustomer.SelectedItem.ToString())
                    {
                        businessCustomer = businessCust;
                    }
                }

                foreach (Car car in Cardealer.Instance.Cars)
                {
                    if (car.Model == comboBoxVehicle.SelectedItem.ToString())
                    {
                        vehicle = (Vehicles)car;
                    }
                }
                foreach (Truck truck in Cardealer.Instance.Trucks)
                {
                    if (truck.Model == comboBoxVehicle.SelectedItem.ToString())
                    {
                        vehicle = (Vehicles)truck;
                    }
                }
                #endregion

                int rentPeriod = int.Parse(txtRentPeriod.Text);

                if (vehicle != null && privatCustomer != null)
                {
                    Cardealer.Instance.LeasePrivate(vehicle, privatCustomer, rentPeriod);
                    MessageBox.Show("Leasing for:\t" + privatCustomer.Name + " and the vehicle " + vehicle.Model
                        + "\n\t\tRent period of " + rentPeriod + " months for " + txtTotalPrice.Text + " DKK");
                }
                if (vehicle != null && businessCustomer != null)
                {
                    Cardealer.Instance.LeaseBusiness(vehicle, businessCustomer, rentPeriod);
                    MessageBox.Show("Leasing for:\t" + businessCustomer.CompanyName + " and the vehicle "
                         + vehicle.Model + "\n\t\tRent period of " + rentPeriod + " months for " + txtTotalPrice.Text + " DKK");
                }
            }
            else
            {
                MessageBox.Show("Missing arguments");
            }
        }

        private void BtnCalculateLeasing_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRentprice.Text) && !string.IsNullOrWhiteSpace(txtRentPeriod.Text))
            {
                double rentPrice = Double.Parse(txtRentprice.Text);
                int rentPeriod = -1;
                try
                {
                    rentPeriod = int.Parse(txtRentPeriod.Text);
                    double total = Cardealer.Instance.GetTotalLeasingPrice(rentPrice, rentPeriod);
                    txtTotalPrice.Text = total + "";
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Rent period is not a number");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtRentprice.Text))
                    MessageBox.Show("Please select a vehicle");
                if (string.IsNullOrWhiteSpace(txtRentPeriod.Text))
                    MessageBox.Show("Please define the rent period");
            }
        }

        private void ComboBoxCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Private privateCustomer in Cardealer.Instance.PrivateCustomers)
            {
                if (privateCustomer.Name == comboBoxCustomer.SelectedItem.ToString())
                {
                    txtName.Text = privateCustomer.Name;
                    txtAddress.Text = privateCustomer.Address;
                }
            }

            foreach (Business businessCustomer in Cardealer.Instance.BusinessCustomers)
            {
                if (businessCustomer.CompanyName == comboBoxCustomer.SelectedItem.ToString())
                {
                    txtName.Text = businessCustomer.CompanyName;
                    txtAddress.Text = businessCustomer.Address;
                }
            }
        }

        private void ComboBoxVehicle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Car car in Cardealer.Instance.Cars)
            {
                if (car.Model == comboBoxVehicle.SelectedItem.ToString())
                {
                    txtModel.Text = car.Model;
                    txtColor.Text = car.Color;
                    txtRentprice.Text = car.RentPrice + "";
                }
            }

            foreach (Truck truck in Cardealer.Instance.Trucks)
            {
                if (truck.Model == comboBoxVehicle.SelectedItem.ToString())
                {
                    txtModel.Text = truck.Model;
                    txtColor.Text = truck.Color;
                    txtRentprice.Text = truck.RentPrice + "";
                }
            }
        }

        private void InitChooseCarComboBox()
        {
            // Cars
            comboChooseCar.Items.Add("---- Cars ----");

            foreach (Car car in Cardealer.Instance.Cars)
            {
                comboChooseCar.Items.Add(car.Model);
            }
            // Trucks
            comboChooseCar.Items.Add("---- Trucks ----");
            foreach (Truck truck in Cardealer.Instance.Trucks)
            {
                comboChooseCar.Items.Add(truck.Model);
            }
            comboChooseCar.SelectedIndex = 0;
        }

        private void InitChooseACustomerComboBox()
        {
            comboChooseCustomer.Items.Add("---- Private ----");
            foreach (Private privateCustomer in Cardealer.Instance.PrivateCustomers)
            {
                comboChooseCustomer.Items.Add(privateCustomer.Name);
            }

            comboChooseCustomer.Items.Add("---- Business ----");
            foreach (Business businessCustomer in Cardealer.Instance.BusinessCustomers)
            {
                comboChooseCustomer.Items.Add(businessCustomer.CompanyName);
            }
            comboChooseCustomer.SelectedIndex = 0;
        }

        // Clicking on a Vehicle in the combobox
        private void ComboChooseCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Car car in Cardealer.Instance.Cars)
            {
                if (car.Model == comboChooseCar.SelectedItem)
                {
                    lblModel.Content = car.Model;
                    lblPrice.Content = car.SalesPrice;
                    lblColor.Content = car.Color;
                }
            }
            foreach (Truck truck in Cardealer.Instance.Trucks)
            {
                if (truck.Model == comboChooseCar.SelectedItem)
                {
                    lblModel.Content = truck.Model;
                    lblPrice.Content = truck.SalesPrice;
                    lblColor.Content = truck.Color;
                }
            }
        }

        private void ComboChooseCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboChooseCustomer.SelectedIndex == 0)
                lblSelectedCustomer.Content = "";
            else
                lblSelectedCustomer.Content = comboChooseCustomer.SelectedItem;
        }

        private void ComboChooseCarLoadded(object sender, RoutedEventArgs e)
        {
            comboChooseCar.Items.Clear();
            InitChooseCarComboBox();
        }

        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            Vehicles vehicle = null;
            Private privatCustomer = null;
            Business businessCustomer = null;

            #region Instantiate Vehicle and customer
            foreach (Private privateCust in Cardealer.Instance.PrivateCustomers)
            {
                if (privateCust.Name == comboChooseCustomer.SelectedItem.ToString())
                {
                    privatCustomer = privateCust;
                }
            }
            foreach (Business businessCust in Cardealer.Instance.BusinessCustomers)
            {
                if (businessCust.CompanyName == comboChooseCustomer.SelectedItem.ToString())
                {
                    businessCustomer = businessCust;
                }
            }
            foreach (Car car in Cardealer.Instance.Cars)
            {
                if (car.Model == comboChooseCar.SelectedItem.ToString())
                {
                    vehicle = (Vehicles)car;
                }
            }
            foreach (Truck truck in Cardealer.Instance.Trucks)
            {
                if (truck.Model == comboChooseCar.SelectedItem.ToString())
                {
                    vehicle = (Vehicles)truck;
                }
            }
            #endregion

            if (vehicle != null && privatCustomer != null)
            {
                Cardealer.Instance.PrivateSale(vehicle, privatCustomer);
                MessageBox.Show("Sale for:\t" + privatCustomer.Name + " and the vehicle " + vehicle.Model);
            }
            if (vehicle != null && businessCustomer != null)
            {
                Cardealer.Instance.BusinessSale(vehicle, businessCustomer);
                MessageBox.Show("Sale for:\t" + businessCustomer.CompanyName + " and the vehicle "
                     + vehicle.Model);
            }
        }

        private void ComboChooseACustomerLoaded(object sender, RoutedEventArgs e)
        {
            comboChooseCustomer.Items.Clear();
            InitChooseACustomerComboBox();
        }
        #endregion
    }
}