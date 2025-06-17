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
        
        public int Experience {  get; set; }
        public string InjuryStatus { get; set; }


        public  Player (int playerID, int sportsID, string firstName, string lastName, int age, string gender, string injuryStatus, int experience)
        {
            PlayersID = playerID;   
            SportsID = sportsID;
            FirstName = firstName;
            LastName = lastName;
            Experience = experience;
            Age = age;
            Gender = gender;
            InjuryStatus = injuryStatus;
      
        }


    
    }

}
