using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Vehicle
{
    public class Truck : Vehicles
    {
        public Truck(string model, string color, double salesPrice, double rentPrice)
            : base(model, color, salesPrice, rentPrice)
        { }
    }
}
