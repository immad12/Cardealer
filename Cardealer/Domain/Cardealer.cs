using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Vehicle;
using Domain.Contracts;
using Foundation;
using System.Collections.ObjectModel;

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

        #region Observable lists
        private ObservableCollection<Car> cars = new ObservableCollection<Car>();

        public ObservableCollection<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }

        private ObservableCollection<Truck> trucks = new ObservableCollection<Truck>();

        public ObservableCollection<Truck> Trucks
        {
            get { return trucks; }
            set { trucks = value; }
        }

        private ObservableCollection<Private> privateCustomers = new ObservableCollection<Private>();
        public ObservableCollection<Private> PrivateCustomers
        {
            get { return privateCustomers; }
            set { privateCustomers = value; }
        }

        private ObservableCollection<Business> businessCustomers = new ObservableCollection<Business>();

        public ObservableCollection<Business> BusinessCustomers
        {
            get { return businessCustomers; }
            set { businessCustomers = value; }
        }

        private ObservableCollection<Leasing> leasingContracts = new ObservableCollection<Leasing>();

        public ObservableCollection<Leasing> LeasingContracts
        {
            get { return leasingContracts; }
            set { leasingContracts = value; }
        }
        private ObservableCollection<Sale> salesContracts = new ObservableCollection<Sale>();

        public ObservableCollection<Sale> SalesContracts
        {
            get { return salesContracts; }
            set { salesContracts = value; }
        }
        #endregion

        private DirectoryWatcher files = new DirectoryWatcher();

        public Cardealer()
        {
            LoadVehiclesFromDB();
            LoadCustomersFromDB();

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

        public void LoadCustomersFromDB()
        {
            privateCustomers.Clear();
            businessCustomers.Clear();

            List<string[]> privateArr = FCustomer.Instance.LoadPrivateCustomers();
            List<string[]> businessArr = FCustomer.Instance.LoadBusinessCustomers();

            // Pasting private customers into list
            foreach (string[] pCustomers in privateArr)
            {
                privateCustomers.Add(new Private(pCustomers[0], pCustomers[1], pCustomers[2], pCustomers[3], pCustomers[4]));
            }
            // Pasting business customers into list
            foreach (string[] bCustomers in businessArr)
            {
                businessCustomers.Add(new Business(bCustomers[0], bCustomers[1], bCustomers[2], bCustomers[3], bCustomers[4]));
            }
        }

        public void UpdateCustomers()
        {

        }
        #endregion

        #region Vehicle methods
        public void RegisterCar(string carType, string model, string color, double salesPrice, double rentPrice, string status)
        {
            if (carType == "car")
            {
                //cars.Add(new Car(model, color, salesPrice, rentPrice));
                Car c = new Car(model, color, salesPrice, rentPrice);
                cars.Add(c);
                
                // Using delegate to fire event
                c.RegisterNewVehicle(AnnounceNewCar);
                c.Announcement();
            }
            else if (carType == "truck")
            {
                //trucks.Add(new Truck(model, color, salesPrice, rentPrice));
                Truck t = new Truck(model, color, salesPrice, rentPrice);
                trucks.Add(t);

                t.RegisterNewVehicle(AnnounceNewCar);
                t.Announcement();
            }
        }

        public void AnnounceNewCar(string msg)
        {
            Console.WriteLine("------------- A new " + msg + " has been added to the system! -------------");
        }
        
        public void LoadVehiclesFromDB()
        {
            trucks.Clear();
            cars.Clear();

            List<string[]> carsArr = FVehicle.Instance.LoadCars();
            List<string[]> truckArr = FVehicle.Instance.LoadTrucks();

            // Pasting cars into list
            foreach (string[] car in carsArr)
            {
                cars.Add(new Car(car[0], car[1], Convert.ToDouble(car[2]), Convert.ToDouble(car[3])));
            }

            // Pasting trucks into list
            foreach (string[] truck in truckArr)
            {
                trucks.Add(new Truck(truck[0], truck[1], Convert.ToDouble(truck[2]), Convert.ToDouble(truck[3])));
            }
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

        public double GetTotalLeasingPrice(double price, int period)
        {
            double total = price * period;
            return total;
        }
        #endregion

        #region Sales methods
        public void PrivateSale(Vehicles vehicle, Private customer)
        {
            salesContracts.Add(new Sale(vehicle, customer));
        }

        public void BusinessSale(Vehicles vehicle, Business customer)
        {
            salesContracts.Add(new Sale(vehicle, customer));
        }
        #endregion
    }
}