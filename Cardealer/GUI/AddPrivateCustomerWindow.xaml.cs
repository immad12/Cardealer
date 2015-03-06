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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;
            string birthday = txtBirthday.Text;
            string genderType = (radioBtnMale.IsChecked == true) ? "male" : "female";

            if (btnSave.Content.ToString() == "Save" && txtName.SelectedText != null && txtAddress.SelectedText != null && txtBirthday != null && txtPhone != null && genderType.Length > 1)
            {
                Cardealer.Instance.RegisterPrivateCustomer(name, address, birthday, phone, genderType);
                this.Close();
            }
            else if (btnSave.Content.ToString() == "OK")
            {
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
