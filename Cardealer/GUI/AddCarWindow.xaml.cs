﻿using System;
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
            CarRadioButton.IsChecked = false;
            TruckRadioButton.IsChecked = false;
            CarModel.Clear();
            CarColor.Clear();
            CarSalePrice.Clear();
            CarRentPrice.Clear();
        }

        private void SaveCarButton_Click(object sender, RoutedEventArgs e)
        {
            String type = (CarRadioButton.IsChecked == true) ? "car" : "truck";
            String model = CarModel.Text;
            String carColor = CarColor.Text;
            double salesPrice = Double.Parse(CarSalePrice.Text);
            double rentPrice = Double.Parse(CarRentPrice.Text);

            if (SaveCarButton.Content.ToString() == "Save" && CarModel.SelectedText != null && CarColor.SelectedText != null && salesPrice > 0 && rentPrice > 0)
            {
                Cardealer.Instance.RegisterCar(type, model, carColor, salesPrice, rentPrice);
                this.Close();
            }
            if (SaveCarButton.Content.ToString() == "OK")
                this.Close();
        }
        #endregion
    }
}
