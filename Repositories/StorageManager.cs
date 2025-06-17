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

    public List<Coaches> GetAllCoaches()
    {
        List <Coaches> coaches = new List<Coaches>();
        string sqlstring = "SELECT * FROM Tbl_Coaches ";
         using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read()) 
                {
                    int CoachID = Convert.ToInt32(reader["Coach_ID"]);
                    int Experience = Convert.ToInt32(reader["Experience"]);
                    int Coach_Type_ID = Convert.ToInt32(reader["Coach_Type_ID"]);
                    string First_Name = reader["First_Name"].ToString();
                    string Last_Name = reader["Last_Name"].ToString();
                    coaches.Add(new Coaches(CoachID, First_Name, Last_Name, Experience,Coach_Type_ID));
                }
            }
         }
         return coaches;
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
  
    public int register(User user)
    {
        using (SqlCommand cmd = new SqlCommand($"INSERT INTO Tbl_Users(Username,PasswordHash, Role, Coach_ID,Player_ID);" +
            $"Values (@First_Name, @Last_Name, @Experience,@Coach_Type_ID); SELECT SCOPE_IDENTITY() ;", conn))
        {
            cmd.Parameters.AddWithValue("@Username", user.UserName);
            cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            cmd.Parameters.AddWithValue("@Role", user.Role);
            cmd.Parameters.AddWithValue("@Coach_ID", user.CoachID);
            cmd.Parameters.AddWithValue("@Player_ID", user.PlayerID);
            return Convert.ToInt32(cmd.ExecuteScalar());

            

        }
    }
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
        using (SqlCommand cmd = new SqlCommand($"update Tbl_Sports SET Sports_Name = @SportsName WHERE SPORTS_ID = @SportsID", conn))
        {
            cmd.Parameters.AddWithValue("SportName", SportsName);
            cmd.Parameters.AddWithValue("SportsID", SportsID);
            return cmd.ExecuteNonQuery();
        }
    }

    public int DeleteSportByName(string SportsName)
    {
        using (SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Tbl_Sports WHERE Sports_Name =@SportsName", conn))
        {
            cmd.Parameters.AddWithValue("@SportsName", SportsName);
            return cmd.ExecuteNonQuery();
        }
    }

    public int InsertNewCoach(Coaches coaches)
    {
        using (SqlCommand cmd = new SqlCommand($"INSERT INTO Tbl_Coaches (First_Name,Last_Name, Experience, Coach_Type_ID)" +
            $"Values (@First_Name, @Last_Name, @Experience,@Coach_Type_ID);" +
            $"SELECT SCOPE_IDENTITY();", conn))
        {

            cmd.Parameters.AddWithValue("@First_Name", coaches.First_Name);
            cmd.Parameters.AddWithValue("@Last_Name", coaches.Last_Name);
            cmd.Parameters.AddWithValue("@Coach_Type_ID", coaches.Coach_Type_ID);
            cmd.Parameters.AddWithValue("@Experience", coaches.Experience);

            object result = cmd.ExecuteScalar(); //gets the generated ID
            return Convert.ToInt32(result);

        }
    }

    public int UpdateCoach(Coaches coaches2)
    {
        using (SqlCommand cmd = new SqlCommand())
        {

            return cmd.ExecuteNonQuery();
            
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

    }

    public int DeleteCoach(Coaches coaches3)
    {
        using (SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Tbl_Coaches WHERE First_Name =@First_Name,", conn))
        {
            return cmd.ExecuteNonQuery();

            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
 
   
    public User Login(string username, string passwordHash)
    {
        string sql = "SELECT * FROM dbo.Tbl_Users WHERE Username = @Username";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@Username", username);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    string StoredPassword = reader["PasswordHash"].ToString();

                    if (StoredPassword == passwordHash)
                    {
                        int userId = Convert.ToInt32(reader["User_ID"]);
                        string role = reader["Role"].ToString();
                        int coachId = reader["coach_ID"] != DBNull.Value ? Convert.ToInt32(reader["Coach_ID"]) : 0;
                        int playerId = reader["Player_ID"] != DBNull.Value ? Convert.ToInt32(reader["Player_ID"]) : 0;

                        return new User(userId, role, coachId, playerId,username,passwordHash);
                    }
                }
            }
        }

        return null;
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

