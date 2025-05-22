using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
                    int CoachID = Convert.ToInt32(reader["Coach_ID"]);
                    string Firstname = reader["First_Name"].ToString();
                    string Lastname = reader["Last_Name"].ToString();
                    int Experience = Convert.ToInt32(reader["Experience"]);
                    int CoachTypeId = Convert.ToInt32(reader["Coach_Type_ID"]);
                    Coaches.Add(new Coaches(CoachID, Firstname, Lastname, Experience, CoachTypeId));
                }
            }
        }
        return Coaches;
    }
    public int UpdateSportsName(int SportsID, string SportsName)
    {
        using (SqlCommand cmd = new SqlCommand($"update SportsName SET Sports_Name = @SportsName WHERE SPORTS_ID = @SportsID", conn))
        {
            cmd.Parameters.AddWithValue("SportName", SportsName);
            cmd.Parameters.AddWithValue("SportsID", SportsID);
            return cmd.ExecuteNonQuery();
        }
    }
}
