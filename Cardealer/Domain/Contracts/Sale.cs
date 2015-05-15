using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Vehicle;


namespace Domain.Contracts
{
    /// <summary>
    /// Niels & Mette, Group 2
    /// Entity object for sale
    /// </summary>
    
    public class Sale : Contract
    {
        //Sale: Information of car and customer and date
        private DateTime salesDate;

        public Sale(Vehicles vehicle, Private customer)
            : base(vehicle, customer)
        {
            salesDate = DateTime.UtcNow.Date;
            vehicle.CarState = "Sold";
        }

        public Sale(Vehicles vehicle, Business customer)
            : base(vehicle, customer)
        {
            salesDate = DateTime.UtcNow.Date;
            vehicle.CarState = "Sold";
        }
    }
}
