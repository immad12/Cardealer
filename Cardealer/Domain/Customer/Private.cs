using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain 
{
    class Private : Customer
    {
        public string Name { get; set; }
        public string Birthdate { get; set; }
        public string Gender { get; set; }

        public Private()
        {

        }

    }
}
