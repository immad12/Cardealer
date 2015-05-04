using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Foundation
{
    public class FVehicle : DatabaseConnection
    {
        public FVehicle()
        {

        }

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
                string command = "insert into cars values ('" +
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
                string command = "insert into trucks values ('" +
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

        public string[] LoadVehicles()
        {
            OpenConnection();

            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from cars";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string[] cars = new string[5];

                    cars[0] = reader[0] + "";
                    cars[1] = reader[1] + "";
                    cars[2] = reader[2] + "";
                    cars[3] = reader[3] + "";
                    cars[4] = reader[4] + "";
                   // carList.Add(reader[0] + "", reader[3] + "", reader[1] + "", reader[4] + "", reader[2] + "";

                    for (int i = 0; i < 5; i++ )
                        Console.WriteLine(cars[i]);

                    yield return cars;
                }

            }

            finally
            {
                connection.Close();
            }
        }
    }
}

//MySqlCommand command = connection.CreateCommand();
//                command.CommandText = "select * from privatecustomers";
//                MySqlDataReader reader = command.ExecuteReader();
//                while (reader.Read())
//                {
//                    return new Car(reader[0] + "", reader[3] + "", reader[1] + "", reader[4] + "", reader[2] + "");
//                }

