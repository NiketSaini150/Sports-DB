using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
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

    public List<Sport> GetALLSports()
    {
        List<Sport> sports = new List<Sport>();
        string sqlString = "SELECT * FROM dbo.Tbl_Sports";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int sportsID = Convert.ToInt32(reader["sports_ID"]);
                    string sportsname = reader["Sports_Name"].ToString();
                    sports.Add(new Sport(sportsID, sportsname));
                }
            }
        }
        return sports;

    }
    public List<Coaches> GetALLCoach()
    {
        List<Coaches> Coaches = new List<Coaches>();
        string sqlString = "SELECT * FROM dbo.Tbl_Coaches";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int CoachID = Convert.ToInt32(reader["sports_ID"]);
                    string Coachname = reader["Sports_Name"].ToString();
                    Coaches.Add(new Coaches(CoachID, Coachname));
                }
            }
        }
        return Coaches;

    }
}
