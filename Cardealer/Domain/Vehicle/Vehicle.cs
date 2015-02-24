using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Vehicle
{
    class Vehicle
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public double SalesPrice { get; set; }
        public double RentPrice { get; set; }

        enum CarState { Commision, Sold, Leased };

        public Vehicle(String model, String color, double salesPrice, double rentPrice, Enum carStatus)
        {
            this.Model = model;
            this.Color = color;
            this.SalesPrice = salesPrice;
            this.RentPrice = rentPrice;
            carStatus = CarState.Commision;
        }
    }
}
