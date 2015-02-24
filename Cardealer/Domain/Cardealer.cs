using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Vehicle;

namespace Domain
{
    public class Cardealer
    {
        private static Cardealer instance;

        public static Cardealer getInstance()
        {
            if (instance == null)
            {
                instance = new Cardealer();
            }
            return instance;
        }

        public static Cardealer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Cardealer();
                }
                return instance;
            }
        }

        private List<Car> cars = new List<Car>();
        private List<Truck> trucks = new List<Truck>();

        public void RegisterCar(String carType, String model, String color, Double salesPrice, Double rentPrice, Enum carStatus)
        {
            if (carType == "car")
            {
                cars.Add(new Car(carType, model, color, salesPrice, rentPrice, carStatus));
            }
            else if (carType == "truck")
            {
                trucks.Add(new Truck(carType, model, color, salesPrice, rentPrice, carStatus));
            }
        }
    }
}
