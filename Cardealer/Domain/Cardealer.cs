using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Vehicle;

namespace Domain
{
    public class Cardealer
    {
        #region Singleton pattern
        private static Cardealer instance;

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
        #endregion

        private List<Car> cars = new List<Car>();
        private List<Truck> trucks = new List<Truck>();

        public Cardealer()
        {
            CreateVehicleData();
        }

        #region Vehicle methods
        public void RegisterCar(String carType, String model, String color, Double salesPrice, Double rentPrice)
        {
            if (carType == "car")
            {
                cars.Add(new Car(model, color, salesPrice, rentPrice));
            }
            else if (carType == "truck")
            {
                trucks.Add(new Truck(model, color, salesPrice, rentPrice));
            }
        }

        public List<Car> GetListOfCars()
        {
            return this.cars;
        }

        public List<Truck> GetListOfTrucks()
        {
            return this.trucks;
        }

        private void CreateVehicleData()
        {
            // Create cars to the cardealership - later this would be in the persistence layer
            RegisterCar("car", "Ford Fiesta", "Silver", 119960, 3250);
            RegisterCar("car", "Ford Mondeo", "Dark blue", 297600, 5250);
            RegisterCar("car", "Citroen C3", "Black", 139990, 3750);
            RegisterCar("car", "Citroen Cactus", "Yellow", 169990, 4350);

            // Create trucks to the cardealership - later this would be in the persistence layer
            RegisterCar("truck", "Iveco Daily", "White", 354300, 4015);
            RegisterCar("truck", "Peugot Boxer", "White", 247250, 2550);
            RegisterCar("truck", "Iveco Daily", "Silver", 325200, 2780);
            RegisterCar("truck", "Volvo FE", "Blue", 623750, 5280);
            RegisterCar("truck", "Volvo FM400", "Blue", 647255, 6725);
        }
        #endregion
    }
}
