using System; // For Exception
using System.Windows.Forms; // For MessageBox
using System.Configuration; // For ConfigurationManager
using MySql.Data.MySqlClient; // For MySqlConnection

namespace brgyProfiling
{
    internal static class Conn
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["BrgyDbConnection"].ConnectionString;

        public static MySqlConnection GetConnection()
        {
            try
            {
                return new MySqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}