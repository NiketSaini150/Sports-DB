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

            storagemanager = new Storagemanager(connectionString);
            view = new Consoleview();
            string choice = view.DisplayMenu();


            switch (choice)
            {
                case "1":
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
                default:
                    Console.WriteLine("Invalid option. Please try again");
                    break;
            }
            storagemanager.closeconnecton();

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
            // int sportId = 0;
            //Sport sport2 = new Sport(sportId, SportName);
            int rowsaffected = storagemanager.DeleteSportByName(SportName);
            view.DisplayMessage($"Rows affected: {rowsaffected} ");
        }
    }
}
