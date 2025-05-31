using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_DB.model
{
    public class Coaches
    {
        public int Coach_ID { get; set; }
        public int Experience { get; set; }
        public int Coach_Type_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }



        public Coaches(int Coach_Id, string First_name, string Last_name, int experience, int Coach_type_ID)
        {
            Coach_ID = Coach_Id;
            Experience = experience;
            Coach_Type_ID = Coach_type_ID;
            First_Name = First_name;
            Last_Name = Last_name;



        }

    }

}
