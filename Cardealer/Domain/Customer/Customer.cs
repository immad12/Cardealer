using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
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

