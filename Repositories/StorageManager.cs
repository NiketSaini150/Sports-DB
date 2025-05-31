using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
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
    /*
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

      public List<Coach_Type> GetALLCoachType()
      {
          List<Coach_Type> Coach_type = new List<Coach_Type>();
          string sqlString = "SELECT * FROM dbo.Tbl_Coach_Type";
          using (SqlCommand cmd = new SqlCommand(sqlString, conn))
          {
              using (SqlDataReader reader = cmd.ExecuteReader())
              {
                  while (reader.Read())
                  {
                      int Coach_Type_ID = Convert.ToInt32(reader["Coach_Type_ID"]);
                      string Coach_Type_name = reader["Coach_Type_Name"].ToString();
                      ;
                      Coach_type.Add(new Coach_Type(Coach_Type_ID, Coach_Type_name));
                  }
              }
          }
          return Coach_type;
      }
  */
    public int InsertNewSport(Sport Sportstemp)
    {
        using (SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Tbl_Sports (Sports_Name) VALUES (@SportName); SELECT SCOPE_IDENTITY();", conn))
        {
            cmd.Parameters.AddWithValue("@SportName", Sportstemp.SportsName);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
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

    public int DeleteSportByName(string SportsName)
    {
        using (SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Tbl_Sports", conn)) 
        {
            cmd.Parameters.AddWithValue("@SportName",SportsName);
            return cmd.ExecuteNonQuery();
        }
    }

   public int InsertNewCoach(Coaches coaches)
   {
        using (SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Tbl_Coaches (First_Name, Experience, Coach_Type_ID)" +
            $"Values (@First_Name, Last_Name, Experience,Coach_Type_ID);" +
            $"SELECT SCOPE_IDENTITY();", conn))
        { 

            cmd.Parameters.AddWithValue("@First_Name", coaches.First_Name);
            return cmd.ExecuteNonQuery();

            cmd.Parameters.AddWithValue("@Last_Name", coaches.Last_Name);
            return cmd.ExecuteNonQuery();

            cmd.Parameters.AddWithValue("@Coach_ID", coaches.Coach_ID);
            return cmd.ExecuteNonQuery();

            cmd.Parameters.AddWithValue("@Coach_Type_ID", coaches.Coach_Type_ID);
            return cmd.ExecuteNonQuery();

            cmd.Parameters.AddWithValue("@Experience", coaches.Experience);
            return cmd.ExecuteNonQuery();

            return Convert.ToInt32(cmd.ExecuteScalar());    

        }
   }

    public int UpdateCoach(Coaches coaches)
    {
        using (SqlCommand cmd = new SqlCommand())
        {

            return cmd.ExecuteNonQuery();

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

    }

    public int DeleteCoach(Coaches coaches)
    {
        using (SqlCommand cmd = new SqlCommand())
        {
            return cmd.ExecuteNonQuery();

            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
    public void closeconnecton()
    {
        if (conn != null && conn.State == ConnectionState.Open)
        {
            conn.Close();
            Console.WriteLine("Connection closed");
        }
    }
}   
