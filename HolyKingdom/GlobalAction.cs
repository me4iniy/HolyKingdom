using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyKingdom
{
    public class GlobalAction
    {
        public class Relocation : GlobalAction
        {
            public string RelocationToID { get; private set; }

            public Relocation(string relocationTo)
            {
                this.RelocationToID = relocationTo;
            }
        }
        public class Visit : GlobalAction
        {
            public string SpotToVisitID { get; private set; }

            public Visit(string spotToVisitID)
            {
                this.SpotToVisitID = spotToVisitID;
            }
        }
        public class Fight : GlobalAction
        {
            public string SpotIDWhereisFight { get; private set; }
            public List<string> PossiblIDsOfEnemies { get; private set; }

            public Fight(List<string> possiblIDsOfEnemies, string spotIDWhereisFight)
            {
                this.PossiblIDsOfEnemies = possiblIDsOfEnemies;
                this.SpotIDWhereisFight = spotIDWhereisFight;
            }
        }
    }
}
