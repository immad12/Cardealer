using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Private : Customer
    {
        public string Name { get; set; }
        public string Birthdate { get; set; }
        public int Gender { get; set; }

        public Private(String name, String address, String birthday, String phone, int gender)
            : base(address, phone)
        {

        }
    }
}
