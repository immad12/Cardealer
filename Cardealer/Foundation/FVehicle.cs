﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Foundation
{
    /// <summary>
    /// Niels & Mette, Group 2
    /// Handling database calls for vehicles
    /// </summary>
    
    public class FVehicle : DatabaseConnection
    {
        public FVehicle()
        {}

        #region Singleton pattern
        private static FVehicle instance;

        public static FVehicle Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FVehicle();
                }
                return instance;
            }
        }
        #endregion

        public void AddCar(string model, string color, double salesPrice, double rentPrice, string status)
        {
            OpenConnection();

            try
            {
                string command = "insert into cardealer.cars values ('" +
                    model + "', '" + color + "', " + Convert.ToInt32(salesPrice) + ", " + 
                    Convert.ToInt32(rentPrice) + ", '" + status + "')";

                MySqlCommand cmd = new MySqlCommand(command, connection);
                cmd.ExecuteNonQuery();
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                connection.Close();
            }
        }

        public void AddTruck(string model, string color, double salesPrice, double rentPrice, string status)
        {
            OpenConnection();

            try
            {
                string command = "insert into cardealer.trucks values ('" +
                    model + "', '" + color + "', " + Convert.ToInt32(salesPrice) + ", " +
                    Convert.ToInt32(rentPrice) + ", '" + status + "')";

                MySqlCommand cmd = new MySqlCommand(command, connection);
                cmd.ExecuteNonQuery();
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                connection.Close();
            }
        }

        public List<string[]> LoadCars()
        {
            OpenConnection();

            List<string[]> carList = new List<string[]>();

            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from cardealer.cars";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string[] cars = new string[5];

                    cars[0] = reader[0] + "";
                    cars[1] = reader[1] + "";
                    cars[2] = reader[2] + "";
                    cars[3] = reader[3] + "";
                    cars[4] = reader[4] + "";
                    
                    carList.Add(cars);
                }
            }

            finally
            {
                connection.Close();
            }

            return carList;
        }

        public List<string[]> LoadTrucks()
        {
            OpenConnection();

            List<string[]> truckList = new List<string[]>();

            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from cardealer.trucks";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string[] trucks = new string[5];

                    trucks[0] = reader[0] + "";
                    trucks[1] = reader[1] + "";
                    trucks[2] = reader[2] + "";
                    trucks[3] = reader[3] + "";
                    trucks[4] = reader[4] + "";

                    truckList.Add(trucks);
                }
            }

            finally
            {
                connection.Close();
            }

            return truckList;
        }
    }
}
