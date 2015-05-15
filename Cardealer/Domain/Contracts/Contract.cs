using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Vehicle;

namespace Domain.Contracts
{
    /// <summary>
    /// Niels & Mette, Group 2
    /// Parent class for entity object for leasing contract and sale contract
    /// </summary>
    
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
