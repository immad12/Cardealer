using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Foundation
{
    public class DatabaseConnection
    {
        //private string connString = "Server=localhost;Database=cardealer;Uid=root;Pwd=ullerslev;";
        private string connString = "Server=localhost;Database=cardealer;Uid=root;Pwd=ullerslev;";

        protected MySqlConnection connection;       

        public DatabaseConnection()
        {}

        protected void OpenConnection()
        {
            connection = new MySqlConnection(connString);
            connection.Open();
        }
    }
}
