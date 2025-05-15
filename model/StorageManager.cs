using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace Sports_DB.model
{
    internal class Storagemanager
    {
        private SqlConnection conn;

        public Storagemanager(string connectionString)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                Console.WriteLine("connection successful");

            }
            catch (Exception E)
            {
                Console.WriteLine("connection NOT successful");
                Console.WriteLine(E.Message);
            }
        }


    }
}
