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
    /// Interaction logic for AddCustomerWindow.xaml
    /// </summary>
    public partial class AddPrivateCustomerWindow : Window
    {
        public AddPrivateCustomerWindow()
        {
            InitializeComponent();
        }

        private void RadioButtonPrivate_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void radioBtnBusiness_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
            String name = txtName.Text;
            String address = txtAddress.Text;
            String phone = txtPhone.Text;
            String birthday = txtBirthday.Text;
            String genderType = (radioBtnMale.IsChecked == true) ? "male" : "female";

            if (btnSave.Content.ToString() == "Save" && txtName.SelectedText != null && txtAddress.SelectedText != null && txtBirthday != null && txtPhone != null && genderType.Length > 1)
            {
                Cardealer.Instance.RegisterPrivateCustomer(name, address, birthday, phone, genderType);
                this.Close();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtAddress.Clear();
            txtBirthday.Clear();
            txtName.Clear();
            txtPhone.Clear();
            radioBtnFemale.IsChecked = false;
            radioBtnMale.IsChecked = false;
        }
    }
}
