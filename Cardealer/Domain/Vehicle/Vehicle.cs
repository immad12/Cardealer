using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Vehicle
{
    class Vehicle
    {
        public double Price { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string NumberPlate { get; set; }

        enum CarState { Commision, Sold, Leased };
    }
}
