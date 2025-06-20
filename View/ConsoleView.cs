using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Sports_DB.model
{
    public class Consoleview
    {
        public string ShowMenu()
        {

        Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("== Main Menu ==");
            Console.WriteLine("1. Table Sports");
            Console.WriteLine("2. Table Coaches");
            Console.WriteLine("3. Table Player ");
            Console.WriteLine("4. Table Coach Type");
            Console.WriteLine("5. Table Trainings");
            Console.WriteLine("6. Register a new Club");
            Console.WriteLine("7. View all users");
            Console.WriteLine("8. Exit");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Input your choice: ");
            return Console.ReadLine().ToUpper();
            
        }
        public string showquaries()
        {
            Console.Clear();
            Console.WriteLine("");
            return Console.ReadLine().ToUpper();
        }

        public string ShowSportsMenu()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("== Sports Menu ==");
            Console.WriteLine("A. List all Records in Table Sports ");
            Console.WriteLine("B. Insert a new Sport");
            Console.WriteLine("C. Update a Sport name by Sports_ID");
            Console.WriteLine("D. Delete a Sport by Sport Name");
            Console.WriteLine("E. Return to Main Menu");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Input your choice: ");

            return Console.ReadLine().ToUpper();
           
        }

        public string ShowCoachMenu()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("== Coach Menu ==");
            Console.WriteLine("A. List all records in Table Coach");
            Console.WriteLine("B. Insert a new Coach");
            Console.WriteLine("B. Update a Coach by Coach ID");
            Console.WriteLine("C. Delete a Coach by Coach Name");
            Console.WriteLine("E. Return to Main Menu ");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Input your choice: ");
            return Console.ReadLine().ToUpper();
        }

        public string ClubPlayerMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("== Player Menu ==");
            Console.WriteLine("A. View all players");
            Console.WriteLine("B. Insert a new Player");
            Console.WriteLine("C. Update a Player");
            Console.WriteLine("D. Return to Main Menu");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Input your choice: ");
            return Console.ReadLine().ToUpper();
        }
        public string ShowPlayerMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("== Player Menu ==");
            Console.WriteLine("A your information");
            Console.WriteLine("C. Logout");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Input your choice: ");
            return Console.ReadLine().ToUpper();

        }

        public string ShowCoachTypeMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("== Coach Type ==");
            Console.WriteLine("A. Insert New Coach Type");
            Console.WriteLine("B. Update New Coach Type");
            Console.WriteLine("C. Return to home page");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Input your choice: ");

            return Console.ReadLine().ToUpper();
        }

        public string ShowTrainingsMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("== Trainings Menu == ");
            Console.WriteLine("A. view all trainings ");
            Console.WriteLine("B. Insert new Training:  ");
            Console.WriteLine("C. Update a Training ");
            Console.WriteLine("D. Return to homepage");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Input your choice: ");
            return Console.ReadLine().ToUpper();
        }
        
        public void DisplayUsers(List<User> users)
        {
            foreach (User user in users)
            {
                Console.WriteLine($"-----------------\nUsername:  {user.UserName}\n Password: {user.PasswordHash}\n Role {user.Role}\n CoachID: {user.CoachID}\n PlayerID: {user.PlayerID}\n ");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public void DisplaySport(List<Sport> sports)
        {
            foreach (Sport sport in sports)
            {
                Console.WriteLine($"----------------\nSports id: {sport.SportsID}\n Sports name: {sport.SportsName}");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public void displayPlayer(List<Player> players)
        {
            foreach (Player player in players)
            {
                Console.WriteLine($"--------------------------\n Player ID: {player.PlayersID}\n" +
                    $" Sports ID: {player.SportsID}\n First Name: {player.FirstName}\n" +
                    $" Last Name: {player.LastName}\n Age: {player.Age}\n" +
                    $" Gender: {player.Gender}\n Experience: {player.Experience}\n" +
                    $" Injury Status: {player.InjuryStatus}  ");

                Console.WriteLine("press any key to contintue");
                Console.ReadKey();
                Console.Clear();
            }
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
            string input;
            bool loop = true;
            do
            {
                Console.WriteLine("please enter your input: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input ))
                {
                    loop = true;
                    Console.WriteLine("please enter a valid input");

                }
                else
                {
                    loop = false;
                }
            }
            while (loop);
            
            return input;

            return Console.ReadLine();
        }

        public int GetIntInput()
        {

            int intInput;
            while (true)
            {
                Console.WriteLine("Please enter a number: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out intInput))
                {
                    return intInput;
                }

                else 
                {
                    Console.WriteLine("Invalid input. Please enter a Valid integer.");
                }
            }
        }
    
       
    }
}
