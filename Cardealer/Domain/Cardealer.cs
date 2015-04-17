using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Vehicle;
using Domain.Contracts;
using Domain.Filesystem;

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
            CreateVehicleData();
            CreateCustomerData();
        }

        #region Customer methods
        public void RegisterPrivateCustomer(string name, string address, string birthday, string phone, string gender)
        {
            privateCustomers.Add(new Private(name, address, birthday, phone, gender));
        }

        public void RegisterBusinessCustomer(string name, string serialno, string address, string phone, string email)
        {
            businessCustomers.Add(new Business(name, serialno, address, phone, email));
        }

        public List<Private> GetListOfPrivateCustomers()
        {
            return this.privateCustomers;
        }

        public List<Business> GetListOfBusinessCustomers()
        {
            return this.businessCustomers;
        }

        public void CreateCustomerData()
        {
            // Create private customers to the cardealership - later this would be in the persistence layer
            RegisterPrivateCustomer("Peter Jacobsen", "Solvænget 5", "24-03-1973", "23658923", "male");
            RegisterPrivateCustomer("Søren Petersen", "Torps Alle 13", "17-10-1969", "89278400", "male");
            RegisterPrivateCustomer("Marie Nielsen", "Heliosvænget 22", "01-05-1988", "89273929", "female");
            RegisterPrivateCustomer("Jakob Mogensen", "Mågevej 12", "03-08-1983", "64021032", "male");
            RegisterPrivateCustomer("Anne Sørensen", "Nørregade 9", "01-12-1975", "63862753", "female");

            // Create business customers to the cardealership - later this would be in the persistence layer
            RegisterBusinessCustomer("BioCover", "20235587", "Kalundborgvej 34", "75728319", "mts@Biocover.dk");
            RegisterBusinessCustomer("Apricity Games", "10047934", "Brogade 2", "56372200", "games@apricity.com");
            RegisterBusinessCustomer("Hair&Nails", "49500360", "Søndergade 17", "60219043", "beauty@hairandnails.com");
        }
        #endregion

        #region Vehicle methods
        public void RegisterCar(string carType, string model, string color, double salesPrice, double rentPrice)
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
