using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_DB
{
    public class Coaches
    {
        public int Coach_ID { get; set; }
        public int Experience_ID { get; set; }
        public int Coach_Type_ID { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }



        public Coaches(int Coach_Id, string First_Name, string Last_Name, int experience, int Coach_type_ID)
        {
            Coach_ID = Coach_Id;
            Experience_ID = experience;
            Coach_Type_ID = Coach_type_ID;
            First_name = First_Name;
            Last_name = Last_Name;
         


        }

    }
     
}
