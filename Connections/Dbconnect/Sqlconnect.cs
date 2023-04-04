using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connections.Dbconnect
{
    public class Sqlconnect
    {
        private static SqlConnection connection;
        private static string connectionString = "Data Source=MSI;Initial Catalog=db_hr_sibkm; Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public static SqlConnection GetConnect()
        {
            try
            {
                connection = new SqlConnection(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return connection;
        }
    }
}
