using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    /// <summary>
    /// Niels & Mette, Group 2
    /// Entity object for private customer
    /// </summary>
    
    public class Private : Customer
    {
        public string Name { get; set; }
        public string Birthdate { get; set; }
        public string Gender { get; set; }

        public Private(String name, String address, String birthday, String phone, String gender)
            : base(address, phone)
        {
            this.Name = name;
            this.Birthdate = birthday;
            this.Gender = gender;
        }
    }
}
