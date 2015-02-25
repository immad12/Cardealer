using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Vehicle;


namespace Domain.Contracts
{
    public class Leasing : Contract
    {
        public double MonthlyRent { get; set; }
        public int RentPeriod { get; set; }
        public DateTime startDate;

        public Leasing(Vehicles vehicle, Private customer, int rentPeriod)
            : base(vehicle, customer)
        {
            this.RentPeriod = rentPeriod;
            startDate = DateTime.UtcNow.Date;

            vehicle.CarState = "Leased";
        }

        public Leasing(Vehicles vehicle, Business customer, int rentPeriod)
            : base(vehicle, customer)
        {
            this.RentPeriod = rentPeriod;
            startDate = DateTime.UtcNow.Date;

            vehicle.CarState = "Leased";
        }
    }
}
