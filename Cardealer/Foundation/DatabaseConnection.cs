using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Foundation
{
    /// <summary>
    /// Niels & Mette, Group 2
    /// Handling database connection
    /// </summary>
    
    public class DatabaseConnection
    {
        // --------------------------------------------------- //
        // -----------------                 ----------------- //
        // ---- MAKE SURE THE connString IS SET PROPERLY ----- //
        // -----------------                 ----------------- // 
        // --------------------------------------------------- //

        private string connString = "Server=localhost;Database=cardealer;Uid=root;Pwd=root;";

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
