using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Vehicle;
using Domain.Contracts;
using Foundation;

namespace Domain
{
    /// <summary>
    /// Controller logic for the cardealer
    /// </summary>
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
        private List<Private> privateCustomers = new List<Private>();
        private List<Business> businessCustomers = new List<Business>();
        private List<Leasing> leasingContracts = new List<Leasing>();

        private DirectoryWatcher files = new DirectoryWatcher();

        public Cardealer()
        {
            LoadVehiclesFromDB();

            DirectoryWatcher watcher = new DirectoryWatcher();
            // -----------------------------------------------------------------------------
            var carType = from t in trucks
                          where
                              t.Color.Contains("Blue")
                          select t.Model;

            Console.WriteLine("-------------------------------------------------------");

            foreach (var carColor in carType)
            {
                Console.WriteLine("Truck type: " + carColor);
            }

            // -----------------------------------------------------------------------------

        }

        #region Customer methods
        public void RegisterPrivateCustomer(string name, string address, string birthday, string phone, string gender)
        {
            //privateCustomers.Add(new Private(name, address, birthday, phone, gender));
            FCustomer.Instance.AddPrivateCustomer(name, birthday, gender, address, Convert.ToInt32(phone));
        }

        public void RegisterBusinessCustomer(string name, string serialno, string address, string phone, string email)
        {
            //businessCustomers.Add(new Business(name, serialno, address, phone, email));
            FCustomer.Instance.AddBusinessCustomer(name, Convert.ToInt32(serialno), address, Convert.ToInt32(phone), email);
        }

        public List<Private> GetListOfPrivateCustomers()
        {
            return this.privateCustomers;
        }

        public List<Business> GetListOfBusinessCustomers()
        {
            return this.businessCustomers;
        }
        #endregion

        #region Vehicle methods
        public void RegisterCar(string carType, string model, string color, double salesPrice, double rentPrice, string status)
        {
            if (carType == "car")
            {
                //cars.Add(new Car(model, color, salesPrice, rentPrice));
                FVehicle.Instance.AddCar(model, color, salesPrice, rentPrice, status);
            }
            else if (carType == "truck")
            {
                //trucks.Add(new Truck(model, color, salesPrice, rentPrice));
                FVehicle.Instance.AddTruck(model, color, salesPrice, rentPrice, status);
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

        public void LoadVehiclesFromDB()
        {
            string[] carsArr = FVehicle.Instance.LoadVehicles();

            this.cars.Add(new Car(carsArr[0] + "", carsArr[1] + "", Convert.ToDouble(carsArr[2]), Convert.ToDouble(carsArr[3])));
        }
        #endregion

        #region Leasing methods
        public void LeasePrivate(Vehicles vehicle, Private customer, int rentPeriod)
        {
            leasingContracts.Add(new Leasing(vehicle, customer, rentPeriod));
        }

        public void LeaseBusiness(Vehicles vehicle, Business customer, int rentPeriod)
        {
            leasingContracts.Add(new Leasing(vehicle, customer, rentPeriod));
        }

        public List<Leasing> getLeasingContrats()
        {
            return leasingContracts;
        }

        public double GetTotalLeasingPrice(double price, int period)
        {
            double total = price * period;
            return total;
        }
        #endregion
    }
}
