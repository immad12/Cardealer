using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Vehicle
{
    class Car : Vehicle
    {
        public Car(String carType, String model, String color, double salesPrice, double rentPrice, Enum carStatus)
            : base(model, color, salesPrice, rentPrice, carStatus)
        {
            carType = "Car";
        }
    }
}
