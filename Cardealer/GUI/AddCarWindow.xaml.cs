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
using Domain;

namespace GUI
{
    /// <summary>
    /// Interaction logic for AddCarWindow.xaml
    /// Logic to create a new car or truck. The window is also used for viewing data about vehicles from datagrid
    /// </summary>
    public partial class AddCarWindow : Window
    {
        public AddCarWindow()
        {
            InitializeComponent();
        }

        #region Eventhandler Buttons
        //Clear all fields for the window
        private void ClearCarButton_Click(object sender, RoutedEventArgs e)
        {
            CarRadioButton.IsChecked = false;
            TruckRadioButton.IsChecked = false;
            CarModel.Clear();
            CarColor.Clear();
            CarSalePrice.Clear();
            CarRentPrice.Clear();
        }

        //Create a new vehicle
        private void SaveCarButton_Click(object sender, RoutedEventArgs e)
        {
            string type = (CarRadioButton.IsChecked == true) ? "car" : "truck";
            string model = CarModel.Text;
            string carColor = CarColor.Text;
            double salesPrice = double.Parse(CarSalePrice.Text);
            double rentPrice = double.Parse(CarRentPrice.Text);

            if (SaveCarButton.Content.ToString() == "Save" && CarModel.SelectedText != null && CarColor.SelectedText != null && salesPrice > 0 && rentPrice > 0)
            {
                Cardealer.Instance.RegisterCar(type, model, carColor, salesPrice, rentPrice, "Commission");
                this.Close();
            }
            if (SaveCarButton.Content.ToString() == "OK")
                this.Close();
        }
        #endregion
    }
}
