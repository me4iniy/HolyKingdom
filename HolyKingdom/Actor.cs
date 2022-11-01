using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyKingdom
{
    public class Actor : Person
    {
        Inventory Inventory = new Inventory();
        public Actor(float HP, float MP, float SP, Stats stats, string name) : base(HP, MP, SP, stats, name)
        {

        }
    }
}
