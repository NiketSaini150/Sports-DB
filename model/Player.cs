using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_DB.model
{
    public class Player
    {
        public int PlayersID  { get; set; }
        public int SportsID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string InjuryStatus { get; set; }


        public  Player (int playerID, int sportsID, string firstName, string lastName, int age, string gender, string injuryStatus)
        {
            PlayersID = playerID;   
            PlayersID = sportsID;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            InjuryStatus = injuryStatus;
      
        }


    
    }

}
