using System.Data;

namespace Sports_DB.model
{
    internal class Program
    {
        private static Storagemanager storagemanager;
        static void Main(string[] args)
        {

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SportsPLSWORK;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            storagemanager  = new Storagemanager(connectionString);

            storagemanager = new Storagemanager(connectionString);
            Consoleview view= new Consoleview ();   
            string choice = view.DisplayMenu();

            switch (choice) 
            {
                case "1":
                    {
                        List<Sport> sports = storagemanager.GetALLSports();
                        view.DisplaySport(sports);
                    }
                    break;
                default:
                    Console.WriteLine("invalid option. please try again");
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
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again");
                    break;
            }

            
        }
    }
}
     