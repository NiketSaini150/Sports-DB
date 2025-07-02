using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Xml;
using Sports_DB.model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sports_DB.Repositories
{
    internal class Program
    {
        private static Storagemanager storagemanager;
        private static Consoleview view;
        static void Main(string[] args)
        {

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\niket\\OneDrive - Avondale College\\Sports DB\\SportsPLSWORK.mdf\";Integrated Security=True;Connect Timeout=30";

            storagemanager = new Storagemanager(connectionString);
            view = new Consoleview();


            int attempts = 4;
            bool Loggedout = false;
            User loggedinuser = null;



            while (attempts > 0 && loggedinuser == null && !Loggedout)
            {

                Console.WriteLine("Username: ");
                string username = Console.ReadLine();

                Console.WriteLine("Password: ");
                string password = Console.ReadLine();

                loggedinuser = storagemanager.Login(username, password);

                if (loggedinuser == null)
                {
                    attempts--;

                    Console.WriteLine($"Login Failed. Attempts remaining: {attempts}");

                    if (attempts <= 0)
                    {
                        Console.WriteLine($"Too many failed attempts, exiting program");
                        return;
                    }

                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();
                    Console.Clear();
                }


                else
                {

                    Console.Clear();
                    Console.WriteLine($"Login successful, role: {loggedinuser.Role} ");


                    switch (loggedinuser.Role)
                    {
                        case "Club":
                            ClubMenu(loggedinuser);


                            break;

                        case "Player":
                            PlayerMenu(loggedinuser);
                            break;

                        case "Coach":
                            CoachMenu(loggedinuser);
                            break;

                        default:
                            Console.WriteLine("Unknown role");
                            break;
                    }

                    Console.WriteLine("logging out");
                    Console.ReadKey();
                    Loggedout = true;
                    break;

                }






                static void ClubMenu(User Manager)
                {

                    bool Exit = false;
                    while (!Exit)
                    {
                        string choice = view.ShowMenu();

                        switch (choice)
                        {
                            case "1":
                                SportsMenu();
                                break;

                            case "2":
                                AdminCoachMenu();
                                break;

                            case "3":
                                AdminPlayerMenu();
                                break;

                            case "4":
                                CoachTypeMenu();
                                break;


                            case "5":
                                TrainingsMenu();
                                break;

                            case "6":
                                Reports();
                                break;

                            case "7":
                                register();
                                break;

                            case "8":
                                List<User> users = storagemanager.GetAllUser();
                                view.DisplayUsers(users);
                                break;

                            case "9":
                                Exit = true;
                                break;

                            default:
                                Console.WriteLine("Invalid option. Please try again");
                                break;
                        }
                    }

                    storagemanager.closeconnecton();
                }
            }

            static void Reports()
            {
                bool Reports = true;

                while (Reports)
                {
                    string report = view.ShowReports();

                    switch (report)
                    {
                        case "A":
                            List<Sport> sports = storagemanager.GetALLSports();
                            view.DisplaySport(sports);
                            break;

                        case "B":
                            List<Coaches> coaches = storagemanager.SimpleQry2();
                            view.displayCoach(coaches);
                            break;
                        case "C":
                            List<Player> players = storagemanager.Simpleqry3();
                            view.displayqry3(players);
                            break;
                        case "D":
                            Reports = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again");
                            break;
                    }
                }
            }
            static void AdminPlayerMenu()
            {
                bool AdminPlayer = true;

                while (AdminPlayer)
                {
                    string adminplayer = view.ClubPlayerMenu();
                    switch (adminplayer)
                    {
                        case "A":
                            List<Player> players = storagemanager.GetALLPlayers();
                            view.displayPlayer(players);

                            break;
                        case "B":
                            InsertPlayer();
                            Console.ReadKey();
                            break;
                        case "C":
                            UpdatePlayer();
                            Console.ReadKey();
                            break;

                        case "D":
                            DeleteSportByName();
                            Console.ReadKey();
                            break;

                        case "E":
                            AdminPlayer = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again");
                            break;

                    }
                }
            }
            static void AdminCoachMenu()
            {
                bool AdminCoach = true;

                while (AdminCoach)
                {
                    string admincoach = view.ShowCoachMenu();

                    switch (admincoach)
                    {
                        case "A":
                            List<Coaches> coaches = storagemanager.GetAllCoaches();
                            view.displayCoach(coaches);
                            break;

                        case "B":
                            InsertNewCoach();
                            Console.ReadKey();

                            break;


                        case "C":
                            UpdateCoach();
                            Console.ReadKey();
                            break;

                        case "D":
                            DeleteCoach();
                            Console.ReadKey();

                            break;

                        case "E":
                            AdminCoach = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again");
                            break;
                    }
                }
            }

            static void SportsMenu()
            {
                bool SportsSubMenu = true;

                while (SportsSubMenu)
                {
                    string subSports = view.ShowSportsMenu();
                    switch (subSports)
                    {
                        case "A":
                            List<Sport> sports = storagemanager.GetALLSports();
                            view.DisplaySport(sports);
                            break;

                        case "B":
                            InsertNewSport();
                            Console.ReadKey();
                            break;

                        case "C":
                            UpdateSportsName();
                            Console.ReadKey();
                            break;

                        case "D":
                            DeleteSportByName();
                            Console.ReadKey();
                            break;


                        case "E":
                            SportsSubMenu = false; // back to the main menu
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again");
                            break;


                    }
                }
            }
            static void CoachMenu(User Coach)
            {
                bool CoachSubMenu = true;
                while (CoachSubMenu)
                {
                    string subCoaches = view.ShowCoachMenu();
                    switch (subCoaches)
                    {
                        case "A":
                            List<Coaches> coaches = storagemanager.GetAllCoaches();
                            view.displayCoach(coaches);
                            break;

                        case "B":
                            InsertNewCoach();
                            Console.ReadKey();
                            break;

                        case "C":
                            UpdateCoach();
                            Console.ReadKey();
                            break;

                        case "D":
                            DeleteCoach();
                            Console.ReadKey();
                            break;

                        case "E":
                            CoachSubMenu = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again");
                            break;

                    }
                }
            }

            static void PlayerMenu(User player)
            {
                bool PlayerSubMenu = true;

                while (PlayerSubMenu)
                {
                    string SubPlayer = view.ShowPlayerMenu();
                    switch (SubPlayer)
                    {
                        case "A":
                            InsertPlayer();
                            Console.ReadKey();
                            break;
                        case "B":
                            UpdatePlayer();
                            Console.ReadKey();
                            break;

                        case "C":
                            PlayerSubMenu = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again");
                            break;
                    }
                }
            }


            static void CoachTypeMenu()
            {
                bool CoachTypeSubMenu = true;

                while (CoachTypeSubMenu)
                {
                    string SubCoach = view.ShowCoachTypeMenu();
                    switch (SubCoach)
                    {
                        case "A":
                           List<Coach_Type> coachtype = storagemanager.GetAllCoachTypes();
                            view.displayCoachType(coachtype);
                            break;
                        case "B":
                            InsertCoachType();
                            Console.ReadKey();
                            break;

                        case "C":
                            UpdateCoachType();
                            Console.ReadKey();
                            break;

                        case "D":
                            DeleteCoachType();
                            Console.ReadKey();
                            break;

                        case "E":
                            CoachTypeSubMenu = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again");
                            break;
                    }
                }
            }

            static void TrainingsMenu()
            {
                bool TrainingsSubMenu = true;

                while (TrainingsSubMenu)
                {
                    string SubTraining = view.ShowTrainingsMenu();
                    switch (SubTraining)
                    {
                        case "A":
                            List<Training> training = storagemanager.GetAllTrainings();
                            view.DisplayTrainings(training);
                            break;


                        case "B":
                            InsertTraining();
                            Console.ReadKey();
                            break;


                        case "C":
                            UpdateTraining();
                            Console.ReadKey();
                            break;

                        case "D": TrainingsSubMenu = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again");
                            break;
                    }
                }
            }


        }

        private static void register()

        {

            view.DisplayMessage("Enter a new username:");
            string username = view.GetInput();

            view.DisplayMessage("Enter a new passoword: ");
            string password = view.GetInput();

            view.DisplayMessage("Enter the coachid (enter 0 if not a coach): ");
            int coachid = view.GetIntInput();

            view.DisplayMessage($"Enter the player id (enter 0 if not a player) : ");
            int playerid = view.GetIntInput();




            view.DisplayMessage("Enter a new role");
            string role = view.GetInput();

            User user1 = new User(0, role, coachid, playerid, username, password);

            try
            {
                int generated_id = storagemanager.register(user1);
                view.DisplayMessage($"New User inserted with ID: {generated_id}");
            }

            catch (Exception ex)
            {
                view.DisplayMessage($"error during registration: {ex.Message}");
            }
            Console.Clear();
        }

        private static void InsertNewSport()
        {
            view.DisplayMessage("Enter the new Sport name: ");
            string SportName = view.GetInput();
            int sportId = 0;
            Sport sport1 = new Sport(sportId, SportName);
            int generated_ID = storagemanager.InsertNewSport(sport1);
            view.DisplayMessage($"New sport inserted with ID: {generated_ID} ");
        }
        private static void UpdateSportsName()
        {

            view.DisplayMessage("Enter the sports_id to update: ");
            int sportsId = view.GetIntInput();

            view.DisplayMessage("Enter the new sport name: ");
            string SportsName = view.GetInput();

            int rowsAffected = storagemanager.UpdateSportsName(sportsId, SportsName);
            view.DisplayMessage($"rows affected: {rowsAffected}");
        }

        private static void DeleteSportByName()
        {
            view.DisplayMessage("Enter the sport name to delete: ");
            string SportName = view.GetInput();
            int sportId = 0;
            Sport sport2 = new Sport(sportId, SportName);
            int rowsaffected = storagemanager.DeleteSportByName(SportName);
            view.DisplayMessage($"Rows affected: {rowsaffected} ");
        }

        private static void InsertNewCoach()
        {
            view.DisplayMessage($"Enter New First Name: ");
            string FirstName = view.GetInput();

            view.DisplayMessage("Enter New Last Name: ");
            string LastName = view.GetInput();

            view.DisplayMessage("Enter New Coach Experience: ");
            int Experience = view.GetIntInput();

            view.DisplayMessage("Enter New Coach Type ID: ");
            int CoachTypeID = view.GetIntInput();


            Coaches coaches2 = new Coaches(0, FirstName, LastName, Experience, CoachTypeID);
            int generatedID2 = storagemanager.InsertNewCoach(coaches2);
            view.DisplayMessage($" New Coach inserted with ID: {generatedID2}");
        }

        private static void UpdateCoach()
        {
            view.DisplayMessage("Coach ID: ");
            int coachid = view.GetIntInput();

            view.DisplayMessage("First Name: ");
            string FirstName = view.GetInput();

            view.DisplayMessage("Last Name: ");
            string LastName = view.GetInput();

            view.DisplayMessage("Experience: ");
            int Experience = view.GetIntInput();

            view.DisplayMessage("Coach Type ID: ");
            int typeid = view.GetIntInput();

            Coaches coach = new Coaches(coachid, FirstName, LastName, Experience, typeid);
            int RowsUpdated = storagemanager.UpdateCoach(coach);
            view.DisplayMessage($"Rows Updated: {RowsUpdated}");
        }
        private static void DeleteCoach()
        {
            view.DisplayMessage("Enter the coach ID to delete:");
            int coachId = view.GetIntInput();

            int rowsAffected = storagemanager.DeleteCoachByID(coachId);
            view.DisplayMessage($"Rows affected: {rowsAffected}");

        }

        private static void InsertPlayer()
        {


            view.DisplayMessage($"Enter New sports ID: ");
            int SportsID = view.GetIntInput();

            view.DisplayMessage($"Enter New First Name: ");
            string FirstName = view.GetInput();

            view.DisplayMessage("Enter New Last Name: ");
            string LastName = view.GetInput();

            view.DisplayMessage("Enter New Age: ");
            int Age = view.GetIntInput();

            view.DisplayMessage("Enter New Gender: ");
            string Gender = view.GetInput();

            view.DisplayMessage("Enter New player Experience: ");
            int Experience = view.GetIntInput();

            view.DisplayMessage("Enter New Injury Status: : ");
            string InjuryStatus = view.GetInput();

            Player player = new Player(0, SportsID, FirstName, LastName, Age, Gender, InjuryStatus, Experience);
            int generatedid = storagemanager.InsertPlayer(player);
            view.DisplayMessage($"New Player inserted with id: {generatedid}");
        }


        private static void UpdatePlayer()
        {
            int playerid = view.GetIntInput();
            if (playerid <= 0)
            {
                view.DisplayMessage("Invalid Player ID. Must be a positive number");
                return;
            }

            view.DisplayMessage("Enter the Sports_id to update: ");
            int sportsId = view.GetIntInput();

            view.DisplayMessage("Enter New Player First Name: ");
            string FirstName = view.GetInput();

            view.DisplayMessage("Enter New Player Last Name: ");
            string LastName = view.GetInput();

            view.DisplayMessage("Enter New Age: ");
            int Age = view.GetIntInput();

            view.DisplayMessage("Enter New gender: ");
            string Gender = view.GetInput();

            view.DisplayMessage("Enter New Player Experience: ");
            int Experience = view.GetIntInput();

            view.DisplayMessage("Enter New Player Injury Status: ");
            string Injurystatus = view.GetInput();

            Player player = new Player(playerid, sportsId, FirstName, LastName, Age, Gender, Injurystatus, Experience);
            int rows = storagemanager.UpdatePlayer(player);
            view.DisplayMessage($"Rows Updated: {rows}");
        }
        private static void InsertTraining()
        {
            view.DisplayMessage($"Enter New sports ID: ");
            int SportsID = view.GetIntInput();

            view.DisplayMessage($"Enter New Coach ID: ");
            int coachid = view.GetIntInput();

            view.DisplayMessage($"Date (yyy-mm-dd): ");
            DateOnly date = DateOnly.Parse(view.GetInput());

            view.DisplayMessage($"Start Time (hh:mm): ");
            TimeSpan start = TimeSpan.Parse(view.GetInput());

            view.DisplayMessage($"End Time (hh:mm): ");
            TimeSpan End = TimeSpan.Parse(view.GetInput());

            Training training = new Training(0, coachid, SportsID, start, End, date);
            int generatedid = storagemanager.InsertTrainings(training);
            view.DisplayMessage($"Training added with ID: {generatedid}");
        }

        private static void UpdateTraining()
        {
            view.DisplayMessage($"Enter Trainings ID to update: ");
            int trainingID = view.GetIntInput();

            view.DisplayMessage($"Enter sports ID to update: ");
            int SportsID = view.GetIntInput();

            view.DisplayMessage($"Enter Coach ID to Update: ");
            int coachid = view.GetIntInput();

            view.DisplayMessage($"Date (yyy-mm-dd): ");
            DateOnly date = DateOnly.Parse(view.GetInput());

            view.DisplayMessage($"Start Time (hh:mm): ");
            TimeSpan start = TimeSpan.Parse(view.GetInput());

            view.DisplayMessage($"End Time (hh:mm): ");
            TimeSpan End = TimeSpan.Parse(view.GetInput());


            Training training = new Training(trainingID, coachid, SportsID, start, End, date);
            int rows = storagemanager.UpdateTrainings(training);
            view.DisplayMessage($" Rows Affected: {rows}");

        }

        private static void InsertCoachType()
        {
            view.DisplayMessage("Enter New Coach Type Name: ");
            string Coachtypename = view.GetInput();

            Coach_Type coachtype = new Coach_Type(0,Coachtypename);
            int generatedid = storagemanager.InserCoachType(coachtype);
            view.DisplayMessage($" New coach type name added with ID: {generatedid}");
        }

        private static void UpdateCoachType()
        {
            view.DisplayMessage("Enter the coach Type id to update: ");
            int Coachtypeid = view.GetIntInput();

            view.DisplayMessage("Enter coach type name: ");
            string coachtype = view.GetInput();

            Coach_Type Coachtype = new Coach_Type(Coachtypeid, coachtype);
            int rows = storagemanager.InserCoachType(Coachtype);
            view.DisplayMessage($" Rows Affected: {rows}");


        }

        private static void DeleteCoachType()
        {

         }

}
    
}




