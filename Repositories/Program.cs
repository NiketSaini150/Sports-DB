using System.Data;
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

                         break;
                           

                    case "5":
                        Exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again");
                        break;
                }
            }
            storagemanager.closeconnecton();

            static void CoachMenu()
            {
                bool CoachSubMenu = true;
                while (CoachSubMenu)
                {
                    string subCoaches = view.ShowCoachMenu();
                    switch(subCoaches)
                    {
                        case "A":

                            break;
                        case "B":
                            InsertNewCoach();
                            Console.ReadKey();
                            break;

                        case "C":
                            DeleteCoachByName();
                            Console.ReadKey();
                            break;

                        case "D":
                            UpdateCoachesName();
                            Console.ReadKey();
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

                        default:
                            view.DisplayMessage("Invalid choice. Press any key to try again: ");
                            Console.ReadKey();
                            break;
                    }
                }
            }
            /*
                    case "":
                        {
                            List<Sport> sports = storagemanager.GetALLSports();
                            view.DisplaySport(sports);
                        }
                        break;

                    case "2":
                        UpdateSportsName();
                        break;

                    case "3":
                        InsertNewSport();
                        break;

                    case "4":
                        DeleteSportByName();
                        break;


                    /*



                                    case "5":
                                        exit = true;
                                        break;

                                     case "6":
                                        {
                                            List<Coaches> coach = storagemanager.GetALLCoach();
                                            view.displayCoach(coach);
                                        }
                                        break;

                                    case "7":
                                        {
                                            List<Coach_Type> coach_Type = storagemanager.GetALLCoachType();
                                            view.displayCoachType(coach_Type);
                                        }
                                        break;
                    */





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

        private static void InsertNewSport()
        {
            view.DisplayMessage("Enter the new Sport name: ");
            string SportName = view.GetInput();
            int sportId = 0;
            Sport sport1 = new Sport(sportId, SportName);
            int generated_ID = storagemanager.InsertNewSport(sport1);
            view.DisplayMessage($"New sport inserted with ID: {generated_ID} ");
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
            view.DisplayMessage ($"Enter New Coach ID : ");
            string coachname = view.GetInput();
            int coachid = 0;

            view.DisplayMessage($"Enter New First Name: ");
            string FirstName = view.GetInput();

            view.DisplayMessage("Enter New Last Name: ");
           string LastName = view.GetInput();

            view.DisplayMessage("Enter New Coach Experience: ");
            int Experience = view.GetIntInput();

            view.DisplayMessage("Enter New Coach Type ID: ");
            int CoachTypeID = view.GetIntInput();


            Coaches coaches2 = new Coaches(coachid, FirstName, LastName, Experience, CoachTypeID);
            int rowsaffected2 = storagemanager.InsertNewCoach(coaches2);
            view.DisplayMessage($" New Coach inserted with ID: {rowsaffected2}");
        }

        private static void DeleteCoachByName()
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

        private static void UpdateCoachesName()
        {

        }
    }
}


