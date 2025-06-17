using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
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

    public List<User> GetAllUser()
    {
        List<User> users = new List<User>();
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_Users",conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int userID = Convert.ToInt32(reader["User_ID"]);
                    string role = reader["Role"].ToString();
                    int coachID = reader ["Coach_ID"] !=DBNull.Value ? Convert.ToInt32(reader["Coach_ID"]):0;
                    int playerID = reader["Player_ID"]!=DBNull.Value ? Convert.ToInt32(reader["Player_ID"]):0;
                    string username= reader["Username"].ToString();
                    string password= reader["PasswordHash"].ToString();

                    users.Add(new User(userID, role, coachID, playerID,username,password));
                }
            }
        }
        return users;
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

    public List<Player> GetALLPlayers()
    {
        List<Player> players = new List<Player>();
        using (SqlCommand cmd = new SqlCommand("SELECT* FROM Tbl_Players;", conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int playerid = Convert.ToInt32(reader["Player_ID"]);
                    string Firstname = reader["First_Name"].ToString();
                    int SportsID = reader["Sports_ID"] != DBNull.Value ? Convert.ToInt32(reader["Sports_ID"]) : 0;
                    string lastname = reader["Last_Name"].ToString();
                    int age = Convert.ToInt32(reader["Age"]);
                    string Gender = reader["Gender"].ToString();
                    string Injury_Status = reader["Injury_Status"].ToString();
                    int Experience = Convert.ToInt32(reader["Experience"]);
                    players.Add(new Player(0, SportsID, Firstname, lastname, age, Gender, Injury_Status, Experience));
                }

            }
            return players;
        }
            
    }
  
    public int register(User user)
    {
        using (SqlCommand cmd = new SqlCommand($"INSERT INTO Tbl_Users (Username,PasswordHash, Role, Coach_ID, Player_ID)" +
            "Values (@Username, @PasswordHash, @Role,@Coach_ID,@Player_ID);" +
            " SELECT Cast(SCOPE_IDENTITY () AS int);", conn))
        {
            cmd.Parameters.AddWithValue("@Username", user.UserName);
            cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            cmd.Parameters.AddWithValue("@Role", user.Role);
            cmd.Parameters.AddWithValue("@Coach_ID", user.CoachID== 0 ? DBNull.Value:(object)user.CoachID);
            cmd.Parameters.AddWithValue("@Player_ID", user.PlayerID == 0 ? DBNull.Value:(Object)user.PlayerID);
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
            "Values (@First_Name, @Last_Name, @Experience,@Coach_Type_ID);" +
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

    public int UpdateCoach(Coaches coaches)
    {
        using (SqlCommand cmd = new SqlCommand("UPDATE Tbl_Coaches SET First_Name=@First_Name, Last_Name=@Last_Name,Experience=@Experience,Coach_Type_ID =@Coach_Type_ID;", conn))
            {

            cmd.Parameters.AddWithValue("@First_Name", coaches.First_Name);
            cmd.Parameters.AddWithValue("@Last_Name", coaches.Last_Name);
            cmd.Parameters.AddWithValue("@Coach_Type_ID", coaches.Coach_Type_ID);
            cmd.Parameters.AddWithValue("@Experience", coaches.Experience);
            cmd.Parameters.AddWithValue("@Coach_ID", coaches.Coach_ID);
            return cmd.ExecuteNonQuery();

        }

         
    }

    public int InsertPlayer(Player player)
    {
        using (SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Players (Sports_ID, First_Name,Last_Name,Age,Gender,Experience,Injury_Status)" +
            "VALUES (@Sports_ID,@First_Name,@Last_Name,@Age,@Gender,@Experience,@Injury_Status);" +
                 $"SELECT SCOPE_IDENTITY();", conn))
        {
            cmd.Parameters.AddWithValue("@Sports_ID", player.SportsID);
            cmd.Parameters.AddWithValue("@First_Name", player.FirstName);
            cmd.Parameters.AddWithValue("@Last_Name", player.LastName);
            cmd.Parameters.AddWithValue("@Age", player.Age);
            cmd.Parameters.AddWithValue("@Gender", player.Gender);
            cmd.Parameters.AddWithValue("@Experience", player.Experience);
            cmd.Parameters.AddWithValue("@Injury_Status", player.InjuryStatus);

            object rowsAffected = cmd.ExecuteScalar();
            return Convert.ToInt32(rowsAffected);
        }
        
        

        
      
    }

    public int DeleteCoachByID(int coachID)
    {
        using (SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Tbl_Coaches WHERE Coach_ID = @Coach_Id", conn))

        {
            cmd.Parameters.AddWithValue("@Coach_ID", coachID);
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected;
           
            
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

