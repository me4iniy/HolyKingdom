using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyKingdom
{
    public class Place
    {
        public string Name;
        public string Description;
        public string ID;

        public List<GlobalAction> PlaceActions { get; private set; }

        public Place(string ID, string name, string description, List<GlobalAction> placeActions)
        {
            this.Name = name;
            this.Description = description;
            this.ID = ID;
            this.PlaceActions = placeActions;
        }
    }
    public class Spot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ID { get; private set; }
        public bool Visible { get; private set; }

        public Spot(string ID, string name, string description, bool visible = true)
        {
            this.Name = name;
            this.Description = description;
            this.ID = ID;
            this.Visible = visible;
        }
        public void ChangeVisible() => Visible = !Visible;
    }
}
