using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Vehicle
{
    public class Car : Vehicles
    {
        public Car(String model, String color, double salesPrice, double rentPrice)
            : base(model, color, salesPrice, rentPrice)
        { }
    }
}
