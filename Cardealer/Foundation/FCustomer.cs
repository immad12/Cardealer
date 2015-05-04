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
        {
            
        }

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
    }
}
