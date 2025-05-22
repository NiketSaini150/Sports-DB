using System.Data;
using Microsoft.IdentityModel.Tokens;

namespace Sports_DB.model
{
    internal class Program
    {
        private static Storagemanager storagemanager;
        private static Consoleview view;
        static void Main(string[] args)
        {

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SportsPLSWORK;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            storagemanager  = new Storagemanager(connectionString);

            storagemanager = new Storagemanager(connectionString);
            view = new Consoleview ();   
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
/*
                case "3":
                    InsertNewSport();
                    break;

                case "4":
                    DeleteSportByName();
                    break;

                case "5":
                    exit = true;
                    break;
*/
                 case "6":
                    {
                        List<Coaches> coach = storagemanager.GetALLCoach();
                        view.displayCoach(coach);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again");
                    break;
            }

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
    }
}
     