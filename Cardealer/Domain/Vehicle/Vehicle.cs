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

        #region Delegate infrastructure
        // Define a delegate type.
        public delegate void NewVehicleHandler(string msgForCaller);
        // Define a member variable of this delegate.
        private NewVehicleHandler listOfHandlers;

        // Add registration function for the caller.
        public void RegisterNewVehicle(NewVehicleHandler methodToCall)
        {
            listOfHandlers += methodToCall;
        }

        public void UnRegisterNewVehicle(NewVehicleHandler methodToCall)
        {
            listOfHandlers -= methodToCall;
        }

        // Implement the method to invoke the delegate’s 
        // invocation list under the correct circumstances.
        public void Announcement()
        {
            if (listOfHandlers != null)
                listOfHandlers(this.Color + " " + this.Model);
        }
        #endregion
    }
}
