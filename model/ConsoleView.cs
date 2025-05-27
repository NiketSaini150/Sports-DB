using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_DB.model
{
    public class Consoleview
    {
        public string DisplayMenu()
        {
            Console.WriteLine("welcome to my sports database");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all records in sports table");
            Console.WriteLine("2. Update a Sports name by Sports_ID");
            Console.WriteLine("3. Insert a new Sport");
            Console.WriteLine("4. Delete a Sport by Sport_Name");
            Console.WriteLine("5. Exit");
            Console.WriteLine("6. View all records in Coaches table");
            Console.WriteLine("7. View all records in Coach type table");
            Console.WriteLine("Select an option");
            return Console.ReadLine();
        }

        public void displayCoach(List<Coaches> coaches)
        {
            foreach (Coaches coach in coaches)
            {
                Console.WriteLine($"{coach.Coach_ID},{coach.Coach_Type_ID},{coach.First_name},{coach.Last_name},{coach.Experience_ID}");
            }
        }
        public void displayCoachType(List<Coach_Type> coach_type)
        {
            foreach (Coach_Type Coach_type in coach_type)
            {
                Console.WriteLine($"{Coach_type.Coach_Type_Id},{Coach_type.Coach_Type_Name}");
            }
        }
        public void DisplaySport(List<Sport> sports)
        {
            foreach (Sport sport in sports)
            {
                Console.WriteLine($"{sport.SportsID}, {sport.SportsName}");
            }

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
