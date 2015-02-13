using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    class Business : Customer
    {
        public string SerialNumber { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }

        public Business()
        {
            
        }
    }
}
