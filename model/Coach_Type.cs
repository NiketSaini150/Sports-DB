using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_DB.model
{
    public class Coach_Type
    {
        public int Coach_Type_ID { get; set; }
        public string Coach_Type_Name { get; set; }

        public Coach_Type(int CoachTypeId, string CoachTypeName)
        {
            Coach_Type_ID = CoachTypeId;
            Coach_Type_Name = CoachTypeName;

        }
    }
}
