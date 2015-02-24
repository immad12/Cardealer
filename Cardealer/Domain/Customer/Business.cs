using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Business : Customer
    {
        public string CompanyName { get; set; }
        public string SerialNumber { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }

        public Business(String name, String serialno, String address, String phone, String fax, String email)
            : base(address, phone)
        {

        }
    }
}
