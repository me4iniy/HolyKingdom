using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyKingdom
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();
        public Item.Armor? EquippedArmor { get; set; } = null;
        public Item.Weapon? EquippedWeapon { get; set; } = null;

        public Inventory()
        {

        }
    }
}
