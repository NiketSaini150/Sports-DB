using System;
using System.Data;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Transactions;
using System.Xml;
using Sports_DB.model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sports_DB.Repositories
{
    public class Program
    {
        private static Storagemanager storagemanager;
        private static Consoleview view;
        static void Main(string[] args)
        {

            // database connection string connected to the local .mdf file in oneDrive
            
            string mdfRelativePath = Path.Combine("mdf files", "SportsPLSWORK.mdf");
            string mdfFullPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, mdfRelativePath));

            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={mdfFullPath};Integrated Security=True;Connect Timeout=30;";


            storagemanager = new Storagemanager(connectionString);
            view = new Consoleview();


            int attempts = 5; // max login attempts 
            bool Loggedout = false; // prevents the user from re logging into the database 
            User loggedinuser = null; // stores the currently logged in user 


            // login loop, ends when the user logs in, logs out, or fails too many login attempts.
            while (attempts > 0 && loggedinuser == null && !Loggedout)
            {

                Console.WriteLine("Username: ");
                string username = Console.ReadLine();


                Console.WriteLine("Password: ");
                string password = Console.ReadLine();

                // prevents blank inputs to cause an crash 
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    Console.Clear();
                    Console.WriteLine("Username and password cannot be empty.");
                    continue; // doesn't waste an attempt

                }
                if (username.Length < 3 || username.Length > 20)
                {
                    Console.Clear();
                    Console.WriteLine("Username must be between 3 and 20 characters");
                    continue;
                }

                if (password.Length < 3 || password.Length > 20)
                {
                    Console.Clear();
                    Console.WriteLine("password must be between 4 and 20 characters");
                    continue;

                }

                // checks the entered username and password against the database.
                // if the username and password match a record in table users, it will log the user in.
                loggedinuser = storagemanager.Login(username, password);

                if (loggedinuser == null)
                {
                    attempts--; // if a login is failed the attempts minus. 

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
                    // successful login, takes the user to the menu based on the role
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
                // club role gets to see this menu and has access to all the tables 
                static void ClubMenu(User Manager)
                {
                    // main menu loop until user chooses to exit
                    bool Exit = false;
                    while (!Exit)
                    {
                        Console.Clear();
                        string choice = view.ShowMenu();
                        // has an error messege for if the user enters something other than the valid options 
                        if (string.IsNullOrWhiteSpace(choice) || choice != "1" && choice != "2" && choice != "3" && choice != "4" &&
                            choice != "5" && choice != "6" && choice != "7" && choice != "8" && choice != "9")
                        {
                            view.DisplayMessage("invalid choice. please select a valid menu number 1-9.");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            continue;
                        }
                        // menu options for each table, and within the table options it has the option to insert update view or delete some records.
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
                                Exit = true; // exits the loop 
                                break;

                            default:
                                Console.WriteLine("Invalid option. Please try again");
                                break;
                        }
                    }
                    // closes the connection 
                    storagemanager.closeconnecton();
                }
            }
            // menu to display all all the reports 
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
                            List<Player> players1 = storagemanager.SimpleQry4();
                            view.displayPlayer(players1);
                            break;
                        case "E":
                            List<Coaches> coaches1 = storagemanager.SimpleQry5();
                            view.displayCoach(coaches1);


                            break;

                        case "F":
                            storagemanager.AdvancedQry1();
                            Console.WriteLine("Press any key to exit ");
                            Console.ReadKey();
                            break;

                        case "G":
                            storagemanager.AdvancedQry2();
                            Console.WriteLine("Press any key to exit ");
                            Console.ReadKey();
                            break;
                        case "H":
                            storagemanager.AdvancedQry3();
                            Console.WriteLine("Press any key to exit ");
                            Console.ReadKey();
                            break;

                        case "I":
                            storagemanager.AdvancedQry4();
                            Console.WriteLine("Press any key to exit ");
                            Console.ReadKey();
                            break;

                        case "J":
                            storagemanager.AdvancedQry5();
                            Console.WriteLine("Press any key to exit ");
                            Console.ReadKey();
                            break;

                        case "K":
                            storagemanager.ComplexQry1();
                            Console.WriteLine("Press any key to exit ");
                            Console.ReadKey();
                            break;

                        case "L":

                            storagemanager.ComplexQry2();
                            Console.WriteLine("Press any key to exit ");
                            Console.ReadKey();
                            break;

                        case "M":
                            storagemanager.ComplexQry3();
                            Console.WriteLine("Press any key to exit ");
                            Console.ReadKey();
                            break;

                        case "N":
                            storagemanager.ComplexQry4();
                            Console.WriteLine("Press any key to exit ");
                            Console.ReadKey();
                            break;

                        case "O":
                            storagemanager.ComplexQry5();
                            Console.WriteLine("Press any key to exit ");
                            Console.ReadKey();
                            break;
                        case "P":
                            Reports = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again");
                            break;
                    }
                }
            }
            // Admin player menu, so only the club can view this 
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
                            AdminPlayer = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again");
                            break;

                    }
                }
            }
            // Admin coach menu, only the club has access to this 
            static void AdminCoachMenu()
            {
                bool AdminCoach = true;

                while (AdminCoach)
                {
                    string admincoach = view.ClubCoachMenu();

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

                            AdminCoach = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again");
                            break;
                    }
                }
            }
            // menu to manage sports records 
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
            // menu to manage coach records
            static void CoachMenu(User Coach)
            {
                bool CoachSubMenu = true;
                while (CoachSubMenu)
                {
                    string subCoaches = view.ShowCoachMenu();
                    switch (subCoaches)
                    {
                        case "A":
                            List<Player> players = storagemanager.GetALLPlayers();
                            view.displayPlayer(players);

                            break;
                        case "B":
                            List<Training> training = storagemanager.GetAllTrainings();
                            view.DisplayTrainings(training);

                            break;

                        case "C":
                            InsertPlayer();
                            Console.ReadKey();
                            break;

                        case "D":
                            UpdatePlayer();
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
            // menu to manage player records
            static void PlayerMenu(User player)
            {
                bool PlayerSubMenu = true;

                while (PlayerSubMenu)
                {
                    string SubPlayer = view.ShowPlayerMenu();
                    switch (SubPlayer)
                    {
                        case "A":
                            List<Training> training = storagemanager.GetAllTrainings();
                            view.DisplayTrainings(training);

                            break;


                        case "B":
                            PlayerSubMenu = false;
                            break;



                        default:
                            Console.WriteLine("Invalid option. Please try again");
                            break;
                    }
                }
            }

            // menu to manage coach type records 
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
            // menu to manage trainings records 
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

                        case "D":
                            TrainingsSubMenu = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again");
                            break;
                    }
                }
            }
        }

        // register a new user by collecting the users inputs for username, password, coach id, playerid, and role.
        // creates a user with the data and inserts it into the database through the storagemanager.
        //after registration is done, it prompts the user to press any key before returning to the main menu

        private static void register()

        {
            Console.Clear();

            string username = view.GetValidStringInput("Enter a new username:", 3, 30);


            string password = view.GetValidStringInput("Enter a new password:", 3, 30);

            view.DisplayMessage("Enter the coachid (enter 0 if not a coach): ");
            int coachid = view.GetValidIntInput("Enter the coach id (enter 0 if not a coach)", 0, 100000);
            coachid = 0;


            int playerid = view.GetValidIntInput($"Enter the player id (enter 0 if not a player)", 0, 100000);
            playerid = 0;

            string role = view.GetValidStringInput("Enter a new role(Club, Player or Coach)", 0, 15);

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
            Console.WriteLine("Press any key to exit ");
            Console.ReadKey();
        }
        // inserts a new sport 
        private static void InsertNewSport()
        {
            string SportName = view.GetValidStringInput("Enter New Sports", 3, 50);
            int sportId = 0;
            Sport sport1 = new Sport(sportId, SportName);
            int generated_ID = storagemanager.InsertNewSport(sport1);
            view.DisplayMessage($"New sport inserted with ID: {generated_ID} ");
        }

        // updates a sport by sports name 
        private static void UpdateSportsName()
        {

            view.DisplayMessage("Enter the sports_id to update: ");
            int sportsId = view.GetValidIntInput("", 0, 10000);


            string SportsName = view.GetValidStringInput("Enter sports name to update", 3, 50);

            int rowsAffected = storagemanager.UpdateSportsName(sportsId, SportsName);
            view.DisplayMessage($"rows affected: {rowsAffected}");
        }
        // deletes a sport by name 
        private static void DeleteSportByName()
        {

            string SportName = view.GetValidStringInput("enter the sports name to delete", 2, 50);
            int sportId = 0;
            Sport sport2 = new Sport(sportId, SportName);
            int rowsaffected = storagemanager.DeleteSportByName(SportName);
            view.DisplayMessage($"Rows affected: {rowsaffected} ");
        }
        //inserts a new coach 
        private static void InsertNewCoach()
        {
            string FirstName = view.GetValidStringInput($"Enter New First Name: ", 1, 50);


            string LastName = view.GetValidStringInput("Enter New Last Name: ", 1, 50);



            int Experience = view.GetValidIntInput("Enter New Coach Experience: ", 0, 50);


            int CoachTypeID = view.GetValidIntInput("Enter New Coach Type ID: ", 0, 10000);


            Coaches coaches2 = new Coaches(0, FirstName, LastName, Experience, CoachTypeID);
            int generatedID2 = storagemanager.InsertNewCoach(coaches2);
            view.DisplayMessage($" New Coach inserted with ID: {generatedID2}");
        }
        // updates an existing coach 
        private static void UpdateCoach()
        {

            int coachid = view.GetValidIntInput("Coach ID", 0, 100000);


            string FirstName = view.GetValidStringInput("First Name: ", 1, 50);


            string LastName = view.GetValidStringInput("Last Name: ", 1, 50);

            view.DisplayMessage("Experience: ");
            int Experience = view.GetValidIntInput("Experience:", 0, 50);


            int typeid = view.GetValidIntInput("Coach Type ID: ", 0, 10000);

            Coaches coach = new Coaches(coachid, FirstName, LastName, Experience, typeid);
            int RowsUpdated = storagemanager.UpdateCoach(coach);
            view.DisplayMessage($"Rows Updated: {RowsUpdated}");
        }
        // inserts a player 
        private static void InsertPlayer()
        {
            view.DisplayMessage($"Enter New sports ID: ");
            int SportsID = view.GetValidIntInput("", 0, 10000);

            string FirstName = view.GetValidStringInput("Enter New First Name ", 1, 50);

            string LastName = view.GetValidStringInput("Enter New Last Name: ", 1, 50);

            int Age = view.GetValidIntInput("Enter new age: ", 7, 50);

            string Gender = view.GetValidStringInput("Enter new gender: ", 1, 50);

            int Experience = view.GetValidIntInput("Enter new player Experience: ", 0, 30);


            string InjuryStatus = view.GetValidStringInput("Enter new injury Status", 2, 50);



         
            Player player = new Player(0, SportsID, FirstName, LastName, Age, Gender, InjuryStatus, Experience);
            int generatedid = storagemanager.InsertPlayer(player);
            view.DisplayMessage($"New Player inserted with id: {generatedid}");
        }
        // updates a player 
        private static void UpdatePlayer()
        {
            int playerid = 0;
            playerid = view.GetValidIntInput($"player ID: {playerid}", 0, 10000);



            view.DisplayMessage("Enter the Sports_id to update: ");
            int sportsId = view.GetValidIntInput("", 0, 10000);

            string FirstName = view.GetValidStringInput("Enter New First Name: ", 1, 50);

            string LastName = view.GetValidStringInput("Enter New Last Name: ", 1, 50);

            view.DisplayMessage("Enter New Age: ");
            int Age = view.GetValidIntInput("", 7,50 );

            string Gender = view.GetValidStringInput("Enter new gender: ", 1, 50);

            view.DisplayMessage("Enter New Player Experience: ");
            int Experience = view.GetValidIntInput("", 0, 30);

            string Injurystatus = view.GetValidStringInput("Enter new injury Status", 2, 50);

            Player player = new Player(playerid, sportsId, FirstName, LastName, Age, Gender, Injurystatus, Experience);
            int rows = storagemanager.UpdatePlayer(player);
            view.DisplayMessage($"Rows Updated: {rows}");

        }

        // inserts a training 
        private static void InsertTraining()
        {
            TimeSpan start, end;
            view.DisplayMessage($"Enter New sports ID: ");
            int SportsID = view.GetValidIntInput("", 0, 10000);

            view.DisplayMessage($"Enter New Coach ID: ");
            int coachid = view.GetValidIntInput("", 0, 10000);

            while (true)
            {

                string StartTime = view.GetValidStringInput("Start Time (hh:mm): ", 0, 5);
                if (TimeSpan.TryParseExact(StartTime, @"hh\:mm", null, out start))
                    break;
                else
                    Console.WriteLine("Invalid Start time format. use HH:MM");


            }

            while (true)
            {

                string EndTime = view.GetValidStringInput("End Time (hh:mm): ", 0, 5);
                if (!TimeSpan.TryParseExact(EndTime, @"hh\:mm", null, out end))
                {
                    Console.WriteLine("Invalid End time format. use HH:MM");
                    continue;
                }
                if (end <= start)
                {
                    Console.WriteLine("End Time Must be Later than Start Time");
                    continue;
                }
                break;
            }

            DateOnly Date;
            while (true)
            {

                string date = view.GetValidStringInput("Date (yyyy-MM-dd):", 0, 10);
                if (DateOnly.TryParse(date, null, out Date))
                {
                    DateOnly today = DateOnly.FromDateTime(DateTime.Today);
                    DateOnly maxDate = today.AddYears(3);

                    if (Date < today)
                    {
                        Console.WriteLine("Training date cannot be in the past");
                        continue;
                    }
                    else if (Date > maxDate)
                    {
                        Console.WriteLine("Training date cannot be more than 3 years in the future ");
                        continue;
                    }
                    break;
                }
                else { Console.WriteLine("Invalid date format. use YYYY-MM-DD"); }
            }

            Training training = new Training(0, coachid, SportsID, start, end, Date);
            int generatedid = storagemanager.InsertTrainings(training);
            view.DisplayMessage($"Training added with ID: {generatedid}");
        }

  

        

    // updates a training
    private static void UpdateTraining()
    {
        TimeSpan start, end;
        view.DisplayMessage($"Enter Trainings ID to update: ");
        int trainingID = view.GetValidIntInput("", 0, 10000);

        view.DisplayMessage($"Enter sports ID to update: ");
        int SportsID = view.GetValidIntInput("", 0, 10000);

        view.DisplayMessage($"Enter Coach ID to Update: ");
        int coachid = view.GetValidIntInput("", 0, 10000);



        while (true)
        {

            string StartTime = view.GetValidStringInput("Start Time (hh:mm):", 0, 5);
            if (TimeSpan.TryParseExact(StartTime, @"hh\:mm", null, out start))
                break;
            else
                Console.WriteLine("Invalid Start time format. use HH:MM");


        }

        while (true)
        {

            string EndTime = view.GetValidStringInput("End Time (hh:mm): ", 0, 5);
            if (!TimeSpan.TryParseExact(EndTime, @"hh\:mm", null, out end))
            {
                Console.WriteLine("Invalid End time format. use HH:MM");
                continue;
            }
            if (end <= start)
            {
                Console.WriteLine("End Time Must be Later than Start Time");
                continue;
            }


            break;
        }

        DateOnly Date;

        while (true)

        {
            string date = view.GetValidStringInput("Date (yyyy-MM-dd):", 0, 10);
            if (DateOnly.TryParse(date, null, out Date))
            {
                DateOnly today = DateOnly.FromDateTime(DateTime.Today);
                DateOnly maxDate = today.AddYears(3);

                if (Date < today)
                {
                    Console.WriteLine("Training date cannot be in the past");
                    continue;
                }
                else if (Date > maxDate)
                {
                    Console.WriteLine("Training date cannot be more than 3 years in the future ");
                    continue;
                }
                break;
            }
            else
            {
                Console.WriteLine("Invalid date format. use YYYY-MM-DD");
            }


        }

            Training training = new Training(trainingID, coachid, SportsID, start, end, Date);
            int rows = storagemanager.UpdateTrainings(training);
            view.DisplayMessage($" Rows Affected: {rows}");
        
    }
    // inserts a coach type 
    private static void InsertCoachType()
    {

        string Coachtypename = view.GetValidStringInput("Enter new coach type name: ", 1, 50);

        Coach_Type coachtype = new Coach_Type(0, Coachtypename);
        int generatedid = storagemanager.InserCoachType(coachtype);
        view.DisplayMessage($" New coach type name added with ID: {generatedid}");
    }
    // updates a coach type 
    private static void UpdateCoachType()
    {
        view.DisplayMessage("Enter the coach Type id to update: ");
        int Coachtypeid = view.GetValidIntInput("", 0, 10000);


        string coachtype = view.GetValidStringInput("Enter new coach type name: ", 1, 50);

        Coach_Type Coachtype = new Coach_Type(Coachtypeid, coachtype);
        int rows = storagemanager.UpdateCoachType(Coachtype);
        view.DisplayMessage($" Rows Affected: {rows}");


    }
    // deletes a coach type by id 
    private static void DeleteCoachType()
    {



        int coachTypeid = view.GetValidIntInput("\"Enter the coach Type ID to delete:\"", 0, 10000);

        int rowsaffected = storagemanager.DeleteCoachTypeById(coachTypeid);
        view.DisplayMessage($"Rows affected: {rowsaffected} ");


    }
    }
}
    





