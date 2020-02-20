using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesKomodo
{
    public class BadgeClass
    {
        public int BadgeID { get; set; }

        public List<string> ListOfDoors { get; set; } = new List<string> ();

        public BadgeClass() { }

        public BadgeClass(int badgeID, List<string> listOfDoors)
        {
            BadgeID = badgeID;
            ListOfDoors = listOfDoors; 
        }


    }
}
