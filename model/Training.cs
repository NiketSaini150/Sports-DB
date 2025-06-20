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
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime Date { get; set; }
        public Training(int trainingID, int coachID, int sportsID, TimeSpan startTime, TimeSpan endTime, DateTime date)
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
