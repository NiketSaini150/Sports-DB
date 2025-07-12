using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Serialization;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Sports_DB.model;
// manages all the interactions with the sql server database
internal class Storagemanager
{
    private SqlConnection conn;

    // constructor connects to the database
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
    
    // gets all trainings records form the database
    public List <Training> GetAllTrainings()
    {
        List <Training> training = new List<Training>();
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_Trainings",conn)) 
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int trainingID = Convert.ToInt32(reader["Trainings_ID"]);
                    int coachID = Convert.ToInt32(reader["Coach_ID"]);
                    int sportsID= Convert.ToInt32(reader["Sports_ID"]);
                    TimeSpan startTime = (TimeSpan) reader ["Start_Time"];
                    TimeSpan endTime = (TimeSpan) reader ["End_Time"];
                    DateOnly date = DateOnly.FromDateTime(Convert.ToDateTime(reader["Training_Date"]));
                    training.Add(new Training(trainingID, coachID, sportsID, startTime, endTime, date));

                }
            }
        }
        return training;
    }
    
    // gets all the coaches records from the database 
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


    // gets all the user records from the database
    public List<User> GetAllUser()
    {
        List<User> users = new List<User>();
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_Users", conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int userID = Convert.ToInt32(reader["User_ID"]);
                    string role = reader["Role"].ToString();
                    int coachID = reader["Coach_ID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Coach_ID"]);
                    int playerID = reader["Player_ID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Player_ID"]);
                    string username = reader["Username"].ToString();
                    string password = reader["PasswordHash"].ToString();

                    users.Add(new User(userID, role, coachID, playerID, username, password));
                }
            }
        }
        return users;
    }

    // gets all the sports records form the data base
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

    //gets all the coach type records from the database 
    public List<Coach_Type> GetAllCoachTypes()
    {
        List<Coach_Type> coach_Types = new List<Coach_Type>();
        using (SqlCommand cmd = new SqlCommand("SELECT* FROM Tbl_Coach_Type;", conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int CoachTypeId = Convert.ToInt32(reader["Coach_Type_ID"]);
                    string CoachTypeName = reader["Coach_Type_Name"].ToString();
                    coach_Types.Add(new Coach_Type(CoachTypeId, CoachTypeName));
                }
            }
        }
        return coach_Types;
    }

    // gets all the player records from the database 
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
                    int SportsID = Convert.ToInt32(reader["Sports_ID"]);
                    string lastname = reader["Last_Name"].ToString();
                    int age = Convert.ToInt32(reader["Age"]);
                    string Gender = reader["Gender"].ToString();
                    string Injury_Status = reader["Injury_Status"].ToString();
                    int Experience = Convert.ToInt32(reader["Experience"]);
                    players.Add(new Player(playerid, SportsID, Firstname, lastname, age, Gender, Injury_Status, Experience));
                }

            }
            return players;
        }

    }
    // gets all coaches with more than 5 years of experience
    public List<Coaches> SimpleQry2()
    {
        List<Coaches> coaches = new List<Coaches>();
        string sqlstring = "SELECT * FROM Tbl_Coaches WHERE Experience>5; ";
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
                    coaches.Add(new Coaches(CoachID, First_Name, Last_Name, Experience, Coach_Type_ID));
                }
            }
        }
        return coaches;
    }

    // gets players with the sports id 1
    public List<Player> Simpleqry3()
    {
        List<Player> players = new List<Player>();
        using SqlCommand cmd = new SqlCommand("SELECT First_Name, Last_Name, Sports_ID FROM Tbl_Players WHERE Sports_ID = 1;", conn);
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int Sportsid = Convert.ToInt32(reader["Sports_ID"]);
                    string Firstname = reader["First_Name"].ToString();
                    string Lastname = reader["Last_Name"].ToString();
                    players.Add(new Player(0,Sportsid, Firstname, Lastname,0,"","",0));
                }
            }
        }
        return players;
    }

    //gets players with the injury status healthy
    public List<Player> SimpleQry4()
    {
        List<Player> players = new List<Player>();
        using (SqlCommand cmd = new SqlCommand("SELECT* FROM Tbl_Players WHERE Injury_Status ='healthy';", conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int playerid = Convert.ToInt32(reader["Player_ID"]);
                    string Firstname = reader["First_Name"].ToString();
                    int SportsID = Convert.ToInt32(reader["Sports_ID"]);
                    string lastname = reader["Last_Name"].ToString();
                    int age = Convert.ToInt32(reader["Age"]);
                    string Gender = reader["Gender"].ToString();
                    string Injury_Status = reader["Injury_Status"].ToString();
                    int Experience = Convert.ToInt32(reader["Experience"]);
                    players.Add(new Player(playerid, SportsID, Firstname, lastname, age, Gender, Injury_Status, Experience));
                }

            }
            return players;
        }

    }

    //gets coaches with the coach type id 2
    public List<Coaches> SimpleQry5()
    {
        List<Coaches> coaches = new List<Coaches>();
        string sqlstring = "SELECT * FROM Tbl_Coaches WHERE Coach_Type_ID = 2; ";
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
                    coaches.Add(new Coaches(CoachID, First_Name, Last_Name, Experience, Coach_Type_ID));
                }
            }
        }
        return coaches;
    }
    // displays each player and the sports they are assigned to 
public void AdvancedQry1()
    {
        using (SqlCommand cmd = new SqlCommand("SELECT P.First_Name AS Player_Name, S.Sports_Name " +
            " FROM Tbl_Players P, Tbl_Sports S, Tbl_Player_Sports ps " +
            "WHERE P.Player_ID = ps.Player_ID " +
            "AND S.Sports_ID = ps.Sports_ID " +
            "ORDER by P.First_Name;", conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("{0,-20} | {1,-20}", "Player Name", "Sports Name");
                Console.WriteLine("-------------------------------");

                while (reader.Read())
                {
                    string playerName = reader["Player_Name"].ToString();
                    string sportsName = reader["Sports_Name"].ToString();
                    Console.WriteLine("{0,-20} | {1,-20}", playerName, sportsName);

                }
            }
        }
    }
    // displays each coach and the sports they coach 
    public void AdvancedQry2()
    {
        using (SqlCommand cmd = new SqlCommand("SELECT c.First_Name As Coach_Name,  S.Sports_Name\r\nFROM Tbl_Coaches c, Tbl_Sports S, Tbl_Coach_Sports cs \r\nWHERE c.Coach_ID = cs.Coach_ID\r\nAND s.Sports_ID = cs.Sports_ID;", conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine(" {0, -20} | {1,-20}", "Coach Name", "Sports Name");
                Console.WriteLine("-----------------------------------");
                while (reader.Read())
                {
                    string coachName = reader["Coach_Name"].ToString();
                    string sportsName = reader["Sports_Name"].ToString();
                    Console.WriteLine("{0,-20} | {1,-20}", coachName, sportsName);
                }
            }
        }

    }
    //displays which player attended which training and who coached them
    public void AdvancedQry3()
    {
        using (SqlCommand cmd = new SqlCommand("SELECT p.First_Name AS Player_Name,P.Last_Name AS Player_Last_Name,T.Training_Date AS Training_Date, C.First_Name AS Coach_Name, C.Last_Name AS Coach_Last_Name\r\nFROM Tbl_Players P, Tbl_Trainings T, Tbl_Coaches C, Tbl_Player_Trainings PT\r\nWHERE P.player_ID = PT.Player_ID \r\nAND T.Trainings_ID = PT.Trainings_ID\r\nAND C.Coach_ID = T.Coach_ID;\r\n", conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("{0,-20} | {1,-25} | {2}", "Player First Name", "Player Last Name", "Coach First Name","Coach Last Name", "Training Date");
                Console.WriteLine("-----------------------------------------------------------------------------------------");

                while (reader.Read())
                {
                    string playerName = reader["Player_Name"].ToString();
                    string Playerlast= reader["Player_Last_Name"].ToString();
                    string coachName = reader["Coach_Name"].ToString();
                    string Coachlast = reader["Coach_Last_Name"].ToString();
                    DateTime date = Convert.ToDateTime(reader["Training_Date"]);
                    Console.WriteLine("{0,-20} | {1,-25} | {2}", playerName, Playerlast, coachName, Coachlast, date);
                }
            }
        }

    }
    //displays player injury status and the sport they play 
    public void AdvancedQry4()
    {
        using (SqlCommand cmd = new SqlCommand("SELECT p.First_Name AS Player_Name,P.Last_Name AS Player_Last_Name,P.Injury_Status,S.Sports_Name\r\nFROM Tbl_Players P, Tbl_Sports S, Tbl_Player_Sports PS\r\nWHERE P.Player_ID = PS.Player_ID \r\nAND S.Sports_ID = PS.Sports_ID;", conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("{0,-15} | {1,-15} | {2,-15} | {3}", "Player Name", "Last Name", "Injury Status", "Sports Name");
                Console.WriteLine("----------------------------------------------------------------------------");

                

                while (reader.Read())
                {
                    string playerName = reader["Player_Name"].ToString();
                    string Playerlast = reader["Player_Last_Name"].ToString();
                    string injuryStatus = reader["Injury_Status"].ToString();
                    string sportsName = reader["Sports_Name"].ToString();
                    Console.WriteLine("{0,-15} | {1,-15} | {2,-15} | {3}", playerName, Playerlast, injuryStatus, sportsName);
                }
            }
        }
    }
    // displays each coach with thir coach type and experience, sorted by experience
    public void AdvancedQry5()
    {
        using (SqlCommand cmd = new SqlCommand("SELECT C.First_Name AS Coach_Name, C.Last_Name as Coach_Last_Name, CT.Coach_Type_Name,C.Experience AS Coach_Experience\r\nFROM Tbl_Coaches C, Tbl_Coach_Type CT\r\nWHERE C.Coach_Type_ID = CT.Coach_Type_ID\r\nORDER BY C.Experience DESC;",conn))
        {
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("{0,-15} | {1,-15} | {2,-20} | {3}", "Coach Name", "Last Name", "Coach Type", "Experience");
                Console.WriteLine("------------------------------------------------------------------------------");

                while (reader.Read())
                {
                    string coachName = reader["Coach_Name"].ToString();
                    string Coachlast = reader["Coach_Last_Name"].ToString();
                    string coachTypeName = reader["Coach_Type_Name"].ToString();
                    int experience = Convert.ToInt32(reader["Coach_Experience"]);
                    Console.WriteLine("{0,-15} | {1,-15} | {2,-20} | {3}", coachName, Coachlast, coachTypeName, experience);

                }
            }
        }
    }
    // displays the number of players in each sport 
    public void ComplexQry1()
    {
        using (SqlCommand cmd = new SqlCommand("SELECT COUNT (P.Player_ID) AS Player_Count, S.Sports_Name\r\nFROM Tbl_Players P,  Tbl_Sports S, Tbl_Player_Sports PS\r\nWHERE P.Player_ID = PS.Player_ID \r\nAND S.Sports_ID = PS.Sports_ID\r\nGROUP BY S.Sports_Name\r\nORDER by Player_Count DESC;", conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("{0,-15} | {1}", "Player Count", "Sports Name");
                Console.WriteLine("----------------------------------");

                while (reader.Read())
                {
                    int Playerid = Convert.ToInt32(reader["Player_Count"]);
                    string Sportsname = reader["Sports_Name"].ToString();
                    Console.WriteLine("{0,-15} | {1}", Playerid, Sportsname);
                }
            }
        }
    }
    // displays top 5 training sessions with the highest player attendance
    public void ComplexQry2()
    {
        using (SqlCommand cmd = new SqlCommand("SELECT TOP 5 T.Trainings_ID AS Training_ID, COUNT (P.Player_ID) AS Player_Count \r\nFROM Tbl_Trainings T,Tbl_Player_Trainings PT, Tbl_Players P\r\nWHERE T.Trainings_ID = PT.Trainings_ID\r\nAND P.Player_ID = PT.Player_ID\r\nGROUP BY T.Trainings_ID\r\nORDER BY Training_ID ASC;", conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("{0,-15} | {1}","Training ID","Player Count");

                while (reader.Read())
                {
                    int trainingid = Convert.ToInt32(reader["Training_ID"]);
                    int playerCount = Convert.ToInt32(reader["Player_Count"]);
                    Console.WriteLine("{0,-15} | {1}", trainingid, playerCount);
                }
            }
        }
    }
    //displays player count by coach and sport
    public void ComplexQry3()
    {
        using (SqlCommand cmd = new SqlCommand("SELECT C.First_Name AS Coach_Name,S.Sports_Name,Count(P.Player_ID) AS Player_Count\r\nFROM Tbl_Coaches C, Tbl_Players P,Tbl_Coach_Sports CS, Tbl_Sports S, Tbl_Player_Sports  PS\r\nWHERE C.Coach_ID = CS.Coach_ID\r\nAND   PS.Sports_ID = S.Sports_ID\r\nAND   P.Player_ID = PS.Player_ID\r\nGROUP BY C.First_Name,S.Sports_Name\r\nORDER BY Player_Count desc;", conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("{0,-15} | {1,-15} | {2} ", "Coach Name", "Sports Name","Player Count");
                Console.WriteLine("------------------------------------------------");

                while (reader.Read()) 
                {
                    string coachName = reader["Coach_Name"].ToString();
                    string Sportsname = reader["Sports_Name"].ToString();
                    int playerCount = Convert.ToInt32(reader["Player_Count"]);
                    Console.WriteLine("{0,-15} | {1,-15} | {2}",coachName, Sportsname, playerCount);

                }
            }
        }
    }
    // displays average player experience per sport
    public void ComplexQry4()
    {
        using (SqlCommand cmd = new SqlCommand("SELECT S.Sports_Name, COUNT (P.Player_ID) AS Player_Count,\r\nAVG(P.Experience) AS Average_Experience\r\nFROM Tbl_Sports S,Tbl_Player_Sports PS, Tbl_Players P \r\nWHERE S.Sports_ID = PS.Sports_ID\r\nAND PS.Player_ID= P.Player_ID\r\nGROUP BY S.Sports_Name\r\nORDER BY Average_Experience DESC;", conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("{0,-20} | {1,-15} | {2}","Sports Name", "Player Count", "Average Experience");
                Console.WriteLine("--------------------------------------------------");

                while (reader.Read())
                {
                    string Sportsname = reader["Sports_Name"].ToString();
                    int playerCount = Convert.ToInt32(reader["Player_Count"]);
                    int averageExperience = Convert.ToInt32(reader["Average_Experience"]);
                    Console.WriteLine("{0,-20} | {1,-15} | {2}", Sportsname, playerCount, averageExperience); 


                }
            }
        }
    }
    // displays how many players attended each coach's training session
    public void ComplexQry5()
    {
        using (SqlCommand cmd = new SqlCommand("SELECT C.First_Name AS Coach_Name, T.Training_Date, COUNT(PT.Player_Trainings_ID)AS Player_Count\r\nFROM Tbl_Coaches C, Tbl_Trainings T, Tbl_Player_Trainings PT\r\nWHERE C.Coach_ID = T.Coach_ID\r\nAND T.Trainings_ID = PT.Trainings_ID\r\nGROUP BY C.First_Name, T.Training_Date\r\nORDER BY Player_Count DESC;", conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("{0,-15} | {1,-12} | {2,14} ", "Coach Name", "Training Date", "Player Count");
                Console.WriteLine("------------------------------------------------");
                while (reader.Read())
                {
                    string coachName = reader["Coach_Name"].ToString();
                    string date = Convert.ToDateTime(reader["Training_Date"]).ToString("dd/MM/yyyy");
                    int playerCount = Convert.ToInt32(reader["Player_Count"]);
                    Console.WriteLine("{0,-15} | {1,-12} | {2,14} ", coachName, date, playerCount);
                }
            }
        }
    }

    // inserts a new sport 
    public int InsertNewSport(Sport Sportstemp)
    {
        using (SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Tbl_Sports (Sports_Name) VALUES (@SportName); SELECT SCOPE_IDENTITY();", conn))
        {
            cmd.Parameters.AddWithValue("@SportName", Sportstemp.SportsName);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }

    // updates the sport 
    public int UpdateSportsName(int SportsID, string SportsName)
    {
        using (SqlCommand cmd = new SqlCommand($"UPDATE Tbl_Sports SET Sports_Name = @SportsName WHERE Sports_ID = @SportsID", conn))
        {
            cmd.Parameters.AddWithValue("@SportsName", SportsName);
            cmd.Parameters.AddWithValue("@SportsID", SportsID);
            
            return cmd.ExecuteNonQuery();
        }
    }

    // deletes the sport by sports name 
    public int DeleteSportByName(string SportsName)
    {
        using (SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Tbl_Sports WHERE Sports_Name =@SportsName", conn))
        {
            cmd.Parameters.AddWithValue("@SportsName", SportsName);
            return cmd.ExecuteNonQuery();
        }
    }

    // inserts a new coach 
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

    // updates the coach 
    public int UpdateCoach(Coaches coaches)
    {
        using (SqlCommand cmd = new SqlCommand("UPDATE Tbl_Coaches SET First_Name=@First_Name, Last_Name=@Last_Name,Experience=@Experience,Coach_Type_ID =@Coach_Type_ID Where Coach_ID =@Coach_ID;", conn))
            {

            cmd.Parameters.AddWithValue("@First_Name", coaches.First_Name);
            cmd.Parameters.AddWithValue("@Last_Name", coaches.Last_Name);
            cmd.Parameters.AddWithValue("@Coach_Type_ID", coaches.Coach_Type_ID);
            cmd.Parameters.AddWithValue("@Experience", coaches.Experience);
            cmd.Parameters.AddWithValue("@Coach_ID", coaches.Coach_ID);
            return cmd.ExecuteNonQuery();

        }

         
    }

// inserts a new player 
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

    //updates the player 
    public int UpdatePlayer(Player player)
    {
         using (SqlCommand cmd = new SqlCommand("UPDATE Tbl_Players SET Sports_ID =@Sports_ID,First_Name =@First_Name,Last_Name=@Last_Name," +
             "Age =@Age, Gender = @Gender,Experience =@Experience, Injury_Status =@Injury_Status " +
             "WHERE Player_ID = @Player_ID", conn))
        {
            cmd.Parameters.AddWithValue("@Player_ID", player.PlayersID);
            cmd.Parameters.AddWithValue("@Sports_ID", player.SportsID);
            cmd.Parameters.AddWithValue("@First_Name", player.FirstName);
            cmd.Parameters.AddWithValue("@Last_Name", player.LastName);
            cmd.Parameters.AddWithValue("@Age", player.Age);
            cmd.Parameters.AddWithValue("@Gender", player.Gender);
            cmd.Parameters.AddWithValue("@Experience", player.Experience);
            cmd.Parameters.AddWithValue("@Injury_Status", player.InjuryStatus);
            return cmd.ExecuteNonQuery();
        } 
      
    }

  // inserts a coach type 
    public int InserCoachType(Coach_Type CoachType)
    {
        using (SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Coach_Type (Coach_Type_Name) VALUES (@Coach_Type_Name); SELECT SCOPE_IDENTITY();", conn))
        {
            
            cmd.Parameters.AddWithValue("@Coach_Type_Name", CoachType.Coach_Type_Name);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
    // updates a coach type 
    public int UpdateCoachType(Coach_Type CoachType)
    {
        using (SqlCommand cmd = new SqlCommand("UPDATE Tbl_Coach_Type SET Coach_Type_Name = @Coach_Type_Name WHERE Coach_Type_ID = @Coach_Type_ID;", conn))
        {

            cmd.Parameters.AddWithValue("@Coach_Type_ID", CoachType.Coach_Type_ID);
            cmd.Parameters.AddWithValue("@Coach_Type_Name", CoachType.Coach_Type_Name);
           
            return cmd.ExecuteNonQuery();

        }
    }
    //deletes the coach type by id 
    public int DeleteCoachTypeById(int coachTypeID)
    {
        using (SqlCommand cmd = new SqlCommand("DELETE FROM Tbl_Coach_Type WHERE Coach_Type_ID =@Coach_Type_ID", conn))
        {
            cmd.Parameters.AddWithValue("@Coach_Type_ID",coachTypeID );
            return cmd.ExecuteNonQuery();
        }
    }
    
    // inserts a new training session into the database 
    public int InsertTrainings(Training training)
    {
        using (SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Trainings (Coach_ID,Sports_ID, Training_Date,Start_Time,End_Time)" +
            " VALUES (@Coach_ID,@Sports_ID, @Training_Date,@Start_Time,@End_Time); " +
            "SELECT SCOPE_IDENTITY();", conn))
        {

            cmd.Parameters.AddWithValue("@Coach_ID", training.CoachID);
            cmd.Parameters.AddWithValue("@Sports_ID",training.SportsID);
            cmd.Parameters.AddWithValue("@Training_Date",training.Date);
            cmd.Parameters.AddWithValue("@Start_Time",training.StartTime);
            cmd.Parameters.AddWithValue("@End_Time",training.EndTime);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
   //updates an existing training session based on id 
    public int UpdateTrainings (Training training)
    {
        using (SqlCommand cmd = new SqlCommand("UPDATE Tbl_Trainings SET  Coach_ID =@Coach_ID, Sports_ID =@Sports_ID," +
            " Training_Date =@Training_Date,Start_Time=@Start_Time,End_Time = @End_Time" +
            " WHERE Trainings_ID = @Trainings_ID;", conn))
        {
            cmd.Parameters.AddWithValue("@Trainings_ID", training.TrainingID);
            cmd.Parameters.AddWithValue("@Coach_ID", training.CoachID);
            cmd.Parameters.AddWithValue("@Sports_ID", training.SportsID);
            cmd.Parameters.AddWithValue("@Training_Date", training.Date);
            cmd.Parameters.AddWithValue("@Start_Time", training.StartTime);
            cmd.Parameters.AddWithValue("@End_Time", training.EndTime);

            return cmd.ExecuteNonQuery();
        }

    }
    // matches the users username and password to the records stored in the database
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

    //registers a new user into the system with the details given and returns the user's id 
    public int register(User user)
    {
        using (SqlCommand cmd = new SqlCommand($"INSERT INTO Tbl_Users (Username,PasswordHash, Role, Coach_ID, Player_ID)" +
            "Values (@Username, @PasswordHash, @Role,@Coach_ID,@Player_ID);" +
            " SELECT Cast(SCOPE_IDENTITY () AS int);", conn))
        {
            cmd.Parameters.AddWithValue("@Username", user.UserName);
            cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            cmd.Parameters.AddWithValue("@Role", user.Role);
            cmd.Parameters.AddWithValue("@Coach_ID", user.CoachID == 0 ? DBNull.Value : (object)user.CoachID);
            //if the coach id is 0, it means that no coachid was inputed, so the db null parameter stores a sql null value in the database to show the absence of a coach id.
            //otherwise, adds the coach id as teh parameter value.
            cmd.Parameters.AddWithValue("@Player_ID", user.PlayerID == 0 ? DBNull.Value : (object)user.PlayerID);
            return Convert.ToInt32(cmd.ExecuteScalar());



        }
    }

    //closes the database connection
    public void closeconnecton()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                Console.WriteLine("Connection closed");
            }
        }

}

