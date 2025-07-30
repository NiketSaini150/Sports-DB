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
            // Displays the main menu options and returns what ever the user choses
        
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
            //display report options for different queries.
            Console.Clear();
            Console.WriteLine("A. View all Sports ID and sports ");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("B. View all coaches with above 5 years of experience ");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("C. view player name registered with sports ID: 1 ");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("D. View all player with the injury status: Healthy ");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("E. View all coaches with less than 5 years of experience");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("F. List all players and the sports they play");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("G. Get all coaches and the sports they coach");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("H. List players, their coach, and training date ");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("I. List players, their injury status, and sports they play  ");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("J. List coaches (Descending) and their coach type ");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("K. Player count per sport (Descending) ");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("L. Top 5 training with player count");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("M. Player count grouped by coach and sport  ");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("N. Sports with player counts and average experience ");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("O. Coaches with training dates and player attendance count");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("P. Return to home page");

            return Console.ReadLine().ToUpper();
        }

        public string ShowSportsMenu()
        {
            // menu option for managing the sports table 
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

        public string ClubCoachMenu()
        {
            //  club menu option for managing the coach table
            Console.Clear();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("== Coach Menu ==");
            Console.WriteLine("A. List all records in Table Coach");
            Console.WriteLine("B. Insert a new Coach");
            Console.WriteLine("C. Update a Coach by Coach ID");
            Console.WriteLine("D. Return to Main Menu ");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Input your choice: ");
            return Console.ReadLine().ToUpper();
        }

        public string ShowCoachMenu()
        {
            // menu for logged in coaches to manage players and trainings
            Console.Clear();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("== Coach Menu ==");
            Console.WriteLine("A. View all players");
            Console.WriteLine("B. View all trainings");
            Console.WriteLine("C. Insert a player ");
            Console.WriteLine("D. Update a Player ");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Input your choice: ");
            return Console.ReadLine().ToUpper();
        }
        public string ClubPlayerMenu()
        {
            // menu for club users to manage player 
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
            // menu for users logged in as player 
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("== Player Menu ==");
            Console.WriteLine("A.View all Trainings");
            Console.WriteLine("B. Logout");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Input your choice: ");
            return Console.ReadLine().ToUpper();

        }

        public string ShowCoachTypeMenu()
        {
            // menu to manage table coach type 
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
            // menu to manage table trainings 
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
        
        // displays user login information for club admins.
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

        // displays a list of all Sports
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

        //displays a list of all players 
        public void displayPlayer(List<Player> players)
        {
            foreach (Player player in players)
            {

                Console.WriteLine($"--------------------------\n Player ID: {player.PlayersID}\n" +
                    $" Sports ID: {player.SportsID}\n First Name: {player.FirstName}\n" +
                    $" Last Name: {player.LastName}\n Age: {player.Age}\n" +
                    $" Gender: {player.Gender}\n Experience: {player.Experience}\n" +
                    $" Injury Status: {player.InjuryStatus}  ");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        // displays all the coaches
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

        //displays all the coach types
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

        // displays filtered player information
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

        //displays all trainings
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

        // displays a single message to the console 
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        // gets string input from the user and validates them 
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

           
        }

       public  string GetValidInput(string prompt, int minLength, int maxLength)

        {

            string input;

            string message;

            bool isValid;



            do

            {

                Console.Write($"{prompt}: ");

                input = Console.ReadLine();

                isValid = IsWithinBoundary(input, minLength, maxLength, out message);



                if (!isValid)

                {

                    Console.WriteLine("Invalid input: " + message);

                }



            } while (!isValid);



            return input;

        }



        public static bool IsWithinBoundary(string input, int minLength, int maxLength, out string message)

        {

            if (input == null)

            {

                message = "Input is null.";

                return false;

            }



            int length = input.Length;



            if (length < minLength)

            {

                message = $"Input is too short. Minimum length is {minLength}, but got {length}.";

                return false;

            }



            if (length > maxLength)

            {

                message = $"Input is too long. Maximum length is {maxLength}, but got {length}.";

                return false;

            }



            message = "Input is within the valid boundary.";

            return true;

        }

        //gets integers inputs from the user and validates them 
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
