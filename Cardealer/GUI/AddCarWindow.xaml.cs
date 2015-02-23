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

            this.Close();
        }
        #endregion
    }
}
