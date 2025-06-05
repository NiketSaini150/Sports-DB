using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_DB.model
{
    internal class User
    {
        public int UserID { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public int CoachID { get; set; }
        public int PlayerID { get; set; }

        public User (int userID, string role, int coachID, int playerID, string username,string password)
        {
            UserID = userID;
            Role = role;
            CoachID = coachID;
            PlayerID = playerID;
            UserName = username;
            PasswordHash = password;
        }
    }
}
