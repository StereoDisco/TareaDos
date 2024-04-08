using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TareaDos.Data_Access
{
    public class DBConnector
    {
        private static string server = "35.212.45.179";
        private static string port = "59222";
        private static string database = "railway";
        private static string uid = "root";
        private static string pwd = "IKeUKVGadQHmrkoEozsyEOwdBrmghheK";
        private static string connectionString = $"server={server};port={port};database={database};uid={uid};pwd={pwd};";

        private static DBConnector instance = null;
        public static DBConnector GetInstance()
        {
            if (instance == null)
            {
                instance = new DBConnector();
            }
            return instance;
        }
        private DBConnector() { }

        public MySqlConnection ConnectToDatabase()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                Console.WriteLine($"Se conectó a BD: {database}.");
                return connection;
            }
            catch (MySqlException e)
            {
                throw new Exception($"Error al coenctar a BD: {database}. Error {e.Message}");
            }
        }
    }
}
