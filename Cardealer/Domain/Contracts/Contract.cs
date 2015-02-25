using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Vehicle;

namespace Domain.Contracts
{
    public class Contract
    {
        public Vehicles Vehicle { get; set; }
        public Customer Customer { get; set; }

        public Contract(Vehicles vehicle, Customer customer)
        {
            this.Vehicle = vehicle;
            this.Customer = customer;
        }
    }
}
