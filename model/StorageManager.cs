using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace Sports_DB.model;

internal class Storagemanager
{
    private SqlConnection conn;

    public Storagemanager(string connectionString)
    {
        try
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            Console.WriteLine("your connection is successful");

        }
        catch (Exception E)
        {
            Console.WriteLine("your connection NOT successful");
            Console.WriteLine(E.Message);
        }
    }

    public List<sports> GetALLSports()
    {
        List<sports> sports = new List<sports>();
        string sqlString = "SELECT * FROM tblSports";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            cmd.Parameters.Clear();
        }


    }
}
