using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Expect.Open.Types.Condition.Types;


namespace brgyProfiling
{
    internal static class Conn
    {
        // Connection string (update with your database details)
        private static readonly string connectionString = "Server=localhost; Database=brgyprofilingsys; uid=root; Password=159632;";

        // Method to get a MySQL connection
        public static MySqlConnection GetConnection()
        {
            try
            {
                return new MySqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating database connection: " + ex.Message);
                throw;
            }
        }
    }
}
