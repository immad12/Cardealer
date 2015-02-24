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
    /// </summary>
    public partial class AddCarWindow : Window
    {
        public AddCarWindow()
        {
            InitializeComponent();
        }

        #region Eventhandler Buttons
        private void ClearCarButton_Click(object sender, RoutedEventArgs e)
        {
            CarModel.Clear();
            CarColor.Clear();
            CarSalePrice.Clear();
            CarRentPrice.Clear();           
        }

        private void SaveCarButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO SAVE A CAR
            //Cardealer.Instance.RegisterCar();

            string type = (c)

            this.Close();
        }
        #endregion

        private void CarRadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TruckRadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
