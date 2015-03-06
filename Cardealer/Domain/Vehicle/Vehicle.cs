using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Vehicle
{
    public class Vehicles
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public double SalesPrice { get; set; }
        public double RentPrice { get; set; }
        public string CarState { get; set; }

        public Vehicles(string model, string color, double salesPrice, double rentPrice)
        {
            this.Model = model;
            this.Color = color;
            this.SalesPrice = salesPrice;
            this.RentPrice = rentPrice;
            CarState = "Commision";
        }
    }
}
