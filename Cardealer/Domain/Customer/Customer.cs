using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Niels & Mette, Group 2
    /// Parent class for entity object for business customers and private customers
    /// </summary>
    
    public class Customer
    {
        public string Address { get; set; }
        public string Phone { get; set; }

        public Customer(String address, String phone)
        {
            this.Address = address;
            this.Phone = phone;
        }
    }
}

