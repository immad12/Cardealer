using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Vehicle
{
    public class Vehicle
    {
        public String Model { get; set; }
        public String Color { get; set; }
        public double SalesPrice { get; set; }
        public double RentPrice { get; set; }
        public String CarState { get; set; }

        public Vehicle(String model, String color, double salesPrice, double rentPrice)
        {
            this.Model = model;
            this.Color = color;
            this.SalesPrice = salesPrice;
            this.RentPrice = rentPrice;
            CarState = "Commision";
        }
    }
}
