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
            Console.WriteLine("6. View Reports");
            Console.WriteLine("7. Register a new Club");
            Console.WriteLine("8. View all users");
            Console.WriteLine("9. Exit");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Input your choice: ");
            return Console.ReadLine().ToUpper();
            
        }

     
        public string ShowReports()
        {
            Console.Clear();
            Console.WriteLine("A. Simple Qry1: ");
            Console.WriteLine("B. Simple Qry2: ");
            Console.WriteLine("C. Simple Qry3: ");
            Console.WriteLine("D. Simple Qry4: ");
            Console.WriteLine("E. Simple Qry5:");
            Console.WriteLine(". Return to home page");

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
            Console.WriteLine("C. Update a Coach by Coach ID");
            Console.WriteLine("D. Delete a Coach by Coach Name");
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
            Console.WriteLine("A. View all coachtypes");
            Console.WriteLine("B. Insert New Coach Type");
            Console.WriteLine("C. Update New Coach Type");
            Console.WriteLine("D. Delete coach type by id ");
            Console.WriteLine("E. Return to home page");
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
                Console.WriteLine($"----------------------------\nUsername:  {user.UserName}\n Password: {user.PasswordHash}\n Role {user.Role}\n CoachID: {user.CoachID}\n PlayerID: {user.PlayerID}\n ");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public void DisplaySport(List<Sport> sports)
        {
            foreach (Sport sport in sports)
            {
                Console.WriteLine($"-----------------------------------------\nSports id: {sport.SportsID}\nSports name: {sport.SportsName}");
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

                Console.WriteLine("press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
         }
        public void displayCoach(List<Coaches> coaches)
        {
            foreach (Coaches coach in coaches)
            {
                Console.WriteLine($"-----------------------------------\n Coach iD: {coach.Coach_ID}\n Coach Type: {coach.Coach_Type_ID}\n First Name: {coach.First_Name}\n Last Name: {coach.Last_Name}\n Experience: {coach.Experience}\n------------------");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public void displayCoachType(List<Coach_Type> coach_type)
        {
            foreach (Coach_Type Coach_type in coach_type)
            {
                Console.WriteLine($"------------------\n Coach Type: {Coach_type.Coach_Type_ID}\n Coach Type Name: {Coach_type.Coach_Type_Name}\n------------------");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

        }

        public void displayqry3(List<Player> player)
        {
            foreach(Player player1 in player)
            {
                Console.WriteLine($"---------------------------\n Sports ID: {player1.SportsID}\n First Name: {player1.FirstName}\n Last Name: {player1.LastName}\n---------------------------");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }


        public void DisplayTrainings(List <Training> training)
        {
            foreach (Training training1 in training)
            {
                Console.WriteLine($"----------------------\n Trainings ID: {training1.TrainingID}\n Coach ID: {training1.CoachID}\n Sports ID: {training1.SportsID}\n Start Time: {training1.StartTime}\n End Time: {training1.EndTime}\n Date:{training1.Date}");
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
                Console.WriteLine("");
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
