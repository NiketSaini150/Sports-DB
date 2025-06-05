using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_DB.model
{
    public class Consoleview
    {
        public string ShowMenu()
        {

        
            Console.WriteLine("== Main Menu ==");
            Console.WriteLine("1. Table Sports");
            Console.WriteLine("2. Table Coaches");
            Console.WriteLine("3. Table Player ");
            Console.WriteLine("4. Table Coach Type");
            Console.WriteLine("5. Table Trainings");
            Console.WriteLine("6. Register a new Club");
            Console.WriteLine("Input your choice: ");
            return Console.ReadLine().ToUpper();
            Console.Clear();
        }

        public string ShowSportsMenu()
        {
            Console.Clear();
            Console.WriteLine("== Sports Menu ==");
            Console.WriteLine("A. List all Records in Table Sports ");
            Console.WriteLine("B. Insert a new Sport");
            Console.WriteLine("C. Delete a Sport by Sport Name");
            Console.WriteLine("D. Update a Sport name by Sports_ID");
            Console.WriteLine("E. Return to Main Menu");
            Console.WriteLine("Input your choice: ");

            return Console.ReadLine().ToUpper();
           
        }

        public string ShowCoachMenu()
        {
            Console.Clear();
            Console.WriteLine("== Coach Menu ==");
            Console.WriteLine("A. Insert a new Coach");
            Console.WriteLine("B. Delete a Coach by Coach Name");
            Console.WriteLine("C. Update a Coach by Coach ID");
            Console.WriteLine("D. Return to Main Menu ");
            Console.WriteLine("Input your choice: ");
            return Console.ReadLine().ToUpper();
        }
        public string ShowPlayerMenu()
        {
            Console.Clear();
            Console.WriteLine("== Player Menu ==");
            Console.WriteLine("A. Insert a new Player");
            Console.WriteLine("B. Delete a Player");
            Console.WriteLine("C. Update a Player");
            Console.WriteLine("D. Return to Main Menu");
            Console.WriteLine("Input your choice: ");
            return Console.ReadLine().ToUpper();

        }

        public string ShowCoachTypeMenu()
        {
            Console.WriteLine("A. Insert New Coach Type");
            Console.WriteLine("B. Update New Coach Type");

            return Console.ReadLine().ToUpper();
        }

        public string ShowTrainingsMenu()
        {
            Console.WriteLine("A. Insert ");
            return Console.ReadLine().ToUpper();
        }
        


        public void DisplaySport(List<Sport> sports)
        {
            foreach (Sport sport in sports)
            {
                Console.WriteLine($"{sport.SportsID}, {sport.SportsName}");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public void displayCoach(List<Coaches> coaches)
        {
            foreach (Coaches coach in coaches)
            {
                Console.WriteLine($"{coach.Coach_ID},{coach.Coach_Type_ID},{coach.First_Name},{coach.Last_Name},{coach.Experience}");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public void displayCoachType(List<Coach_Type> coach_type)
        {
            foreach (Coach_Type Coach_type in coach_type)
            {
                Console.WriteLine($"{Coach_type.Coach_Type_ID},{Coach_type.Coach_Type_Name}");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

        }
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }

        public int GetIntInput()
        {
            return int.Parse(Console.ReadLine());
        }
    }
}
