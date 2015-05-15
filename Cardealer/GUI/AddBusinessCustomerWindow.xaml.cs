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
    /// Niels & Mette, Group 2
    /// Interaction logic for AddCustomerWindow
    /// </summary>
    
    public partial class AddBusinessCustomerWindow : Window
    {
        public AddBusinessCustomerWindow()
        {
            InitializeComponent();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtCompanyName.Clear();
            txtSerialNo.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = txtCompanyName.Text;
            string serialno = txtSerialNo.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;

            if (btnSave.Content.ToString() == "Save" && txtCompanyName.SelectedText != null && txtAddress.SelectedText != null 
                && txtSerialNo.SelectedText != null && txtPhone.SelectedText != null && txtEmail.SelectedText != null)
            {
                Cardealer.Instance.RegisterBusinessCustomer(name, serialno, address, phone, email);
                Cardealer.Instance.LoadCustomersFromDB();
                this.Close();
            }
            else if (btnSave.Content.ToString() == "OK")
            {
                this.Close();
            }
        }
    }
}
