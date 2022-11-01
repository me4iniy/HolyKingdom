using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyKingdom
{
    public class Inventory
    {
        private readonly List<Item> _items;
        public Inventory()
        {
            _items = new List<Item>();
        }
    }
}
