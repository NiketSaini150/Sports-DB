using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using Sports_DB.model;

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

        
            Storagemanager storage = new Storagemanager(connectionString);

            Console.WriteLine("Username: ");
            string username = Console.ReadLine();

            Console.WriteLine( "{Password: ");
            string password = Console.ReadLine();

            User loggedinuser = storage.Login(username, password);

            if (loggedinuser != null)
            {
                Console.WriteLine($"Login successful role: {loggedinuser} ");

                switch (loggedinuser.Role)
                {
                    case "Club":
                        Console.WriteLine("FUll ACCESS TO CLUB");
                        ClubMenu(loggedinuser);
                        break;

                    case "Player":
                        PlayerMenu(loggedinuser);
                        break;

                    default:
                        Console.WriteLine("Unknown role");
                        break;
                }
            }
            else
            {
                Console.WriteLine("login failed\nCheck username and password.");
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
                            CoachMenu();
                            break;

                        case "3":
                            
                            break;

                        case "4":
                            CoachTypeMenu();
                            break;


                        case "5":
                            TrainingsMenu();
                            break;

                        case "6":
                            Exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again");
                            break;
                    }
                }

                storagemanager.closeconnecton();
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
                            DeleteSportByName();
                            Console.ReadKey();
                            break;

                        case "D":
                            UpdateSportsName();
                            Console.ReadKey();
                            break;


                        case "E":
                            SportsSubMenu = false; // back to the main menu
                            break;

                        
                    }
                }
             }
                static void CoachMenu()
                {
                    bool CoachSubMenu = true;
                    while (CoachSubMenu)
                    {
                        string subCoaches = view.ShowCoachMenu();
                        switch (subCoaches)
                        {
                            case "A":
                                InsertNewCoach();
                                Console.ReadKey();
                                break;
                            
                            case "B":
                                DeleteCoach();
                                Console.ReadKey();
                                break;


                            case "C":
                                UpdateCoach();
                                Console.ReadKey();
                                break;

                            case "D":
                                CoachSubMenu = false;
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
                              //  InsertNewPlayer();
                                Console.ReadKey();
                                break;
                        case "D":
                            PlayerSubMenu = false;
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
                            //  InsertNewCoachType();
                            Console.ReadKey();
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
                            //  InsertNewPlayer();
                            Console.ReadKey();
                            break;
                    }
                        }
                }
      
        





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

            
        }
        private static void DeleteCoach()
        {
            view.DisplayMessage($"Enter the coach First Name you want to Delete");
            string FirstName = view.GetInput();

            view.DisplayMessage("Enter the coach Last Name you want to Delete");
            string LastName = view.GetInput();

            view.DisplayMessage("Enter the Coach Experience you want to Delete");
            int Experience = view.GetIntInput();

            view.DisplayMessage("Enter The Coach Type Id you want to be Delete");
            int CoachTypeID = view.GetIntInput();

        }

       

        private static void InsertPlayer()
        {

        }

        private static void DeletePlayer()
        {

        }
        private static void UpdatePlayer()
        {

        }
    }
}


