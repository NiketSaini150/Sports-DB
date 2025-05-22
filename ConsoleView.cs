using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_DB
{
    public class Consoleview
    {
        public string DisplayMenu()
        {
            Console.WriteLine("welcome to my sports database");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all records in brand");
            Console.WriteLine("2. Update a Sports name by Sports_ID");
            Console.WriteLine("3. Insert a new Sport");
            Console.WriteLine("4. Delete a Sport by Sport_Name");
            Console.WriteLine("Selecet an option");
            return Console.ReadLine();
        }
        public void DisplaySport (List <Sport> sports)
        {
            foreach (Sport sport in sports)
            {
                Console.WriteLine($"{sport.SportsID}, {sport.SportsName}");
            }

        }
    }
}
