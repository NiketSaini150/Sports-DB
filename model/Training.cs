using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_DB.model
{
    public class Training
    {
        public int TrainingID { get; set; }
        public int CoachID { get; set; }
        public int SportsID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateOnly Date { get; set; }
        public Training(int trainingID, int coachID, int sportsID, DateTime startTime, DateTime endTime, DateOnly date)
        {
            TrainingID = trainingID;
            CoachID = coachID;
            SportsID = sportsID;
            StartTime = startTime;
            EndTime = endTime;
            Date = date;

        }

    }
}
