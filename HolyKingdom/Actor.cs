using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyKingdom
{
    public class Actor : Person
    {
        public float Money { get; private set; } = 0f;
        public Inventory Inventory { get; private set; } = new Inventory();

        public Actor(float HP, float MP, float SP, Stats stats, string name) : base(HP, MP, SP, stats, name)
        {

        }
    }
}
