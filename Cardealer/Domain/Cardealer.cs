﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Vehicle;
using Domain.Contracts;
using System.Collections.ObjectModel;
using System.Diagnostics;

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
        #endregion

        private DirectoryWatcher files = new DirectoryWatcher();

        public Cardealer()
        {
            CreateVehicleData();
            CreateCustomerData();
            DirectoryWatcher watcher = new DirectoryWatcher();
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
            Trace.WriteLine("*-------------* A new " + msg + " has been added to the system! *-------------*");
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

        public double GetTotalLeasingPrice(double price, int period)
        {
            double total = price * period;
            return total;
        }
        #endregion
    }
}