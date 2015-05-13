using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Foundation
{
    public class FCustomer : DatabaseConnection
    {
        public FCustomer()
        {}

        #region Singleton pattern
        private static FCustomer instance;

        public static FCustomer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FCustomer();
                }
                return instance;
            }
        }
        #endregion

        public void AddPrivateCustomer(string name, string birthdate, string gender, string address, int phone)
        {
            OpenConnection();

            try
            {
                string command = "insert into privatecustomers values ('" +
                    name + "', '" + birthdate + "', '" + char.ToUpper(gender[0]) + gender.Substring(1) + "', '" + address + "', '" + phone + "')";

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

        public void AddBusinessCustomer(string name, int serialno, string address, int phone, string email)
        {
            OpenConnection();

            try
            {
                string command = "insert into businesscustomers values ('" +
                    name + "', '" + serialno + "', '" + email + "', '" + address + "', '" + phone + "')";

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

        public List<string[]> LoadPrivateCustomers()
        {
            OpenConnection();

            List<string[]> privateList = new List<string[]>();

            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from privatecustomers";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string[] privateArr = new string[5];

                    privateArr[0] = reader[0] + "";
                    privateArr[1] = reader[3] + "";
                    privateArr[2] = reader[1] + "";
                    privateArr[3] = reader[4] + "";
                    privateArr[4] = reader[2] + "";

                    privateList.Add(privateArr);
                }
            }

            finally
            {
                connection.Close();
            }

            return privateList;
        }

        public List<string[]> LoadBusinessCustomers()
        {
            OpenConnection();

            List<string[]> businessList = new List<string[]>();

            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from businesscustomers";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string[] businessArr = new string[5];

                    businessArr[0] = reader[0] + "";
                    businessArr[1] = reader[1] + "";
                    businessArr[2] = reader[3] + "";
                    businessArr[3] = reader[4] + "";
                    businessArr[4] = reader[2] + "";

                    businessList.Add(businessArr);
                }
            }

            finally
            {
                connection.Close();
            }

            return businessList;
        }
    }
}
