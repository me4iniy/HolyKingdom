using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HolyKingdom.Item;

namespace HolyKingdom
{
    public static class Data
    {
        private static List<Item> _AllItems = new();
        private static List<Place> _AllPlacesID = new();
        private static List<Spot> _AllSpotsID = new();

        //private static List<Item.Heal> _AllHeals = new List<Item.Heal>();
        //private static List<Item.Resource> _AllResources = new List<Item.Resource>();

        public static Item? GetItemPerID(string ID)
        {
            foreach(Item item in _AllItems)
                if(item.ID==ID)
                    return item;

            return null;
        }

        //string UserRoot = Environment.GetEnvironmentVariable("USERPROFILE");

        private static Item GetRandomItem(int userLvl)
        {
            List<Item> items = new List<Item>();

            foreach(Item.Armor armor in _AllItems)
                if(armor.LVL==1)
                    items.Add(armor);

            Random random = new Random();

            return items[random.Next(0, items.Count-1)];
        }

        public static void CreateDefaultGame()
        {
            CreateDefaultItems();
            CreateDefaultPlaces();
        }
        private static void CreateDefaultItems()
        {
            _AllItems.Add(new Item.Weapon(Item.Weapon.TypesOfWeapon.ShortSword, new Elementary.ElementaryElements(2, 0, 0, 0, 0), "Ржавый короткий меч", "Есть ощущение, что этот меч пролежал в земле несколько лет.", 10f, 1, 1, "W00001"));
            _AllItems.Add(new Item.Armor(Item.Armor.TypesOfArmor.Light, new Elementary.ElementaryElements(0, 0, 0, 0, 0), "Майка", "В ней ТАК свежо... А, похоже в ней еще и дырка.", 10f, 0.2f, 1, "A00001"));
        }
        private static void CreateDefaultPlaces()
        {
            _AllSpotsID.Add(new Spot("SP0001", "Алтарь", "Замшелая конструкция, выглядит как алтарь."));
            _AllSpotsID.Add(new Spot("SP0002", "Колодец", "Вы подошли поближе и заглянули во внутрь. Внутри много различного хлама, который навален как будто специально."));
            _AllSpotsID.Add(new Spot("SP0003", "Часовня", "Увидев издалека шпиль, возвышающийся над домами вы быстро догадались, что это часовня. Ноги сами понесли вас туда. Здание выглядит удивительно целым. Вы бродите внутри и обнаруживаете ключ, на нем написано 'Отец Артур'"));
            _AllSpotsID.Add(new Spot("SP0002", "Дом священника", "Вы долго бродили по деревне открывая двери, наконец ваш ключ подошел. Проникнув во внутрь вы едва не теряете сознание от вони. Вы с силой разжимаете слезящиеся глаза, и полутеме замечаете как к вам бежит существо.", false));

            _AllPlacesID.Add(new Place("PT0001", "Алтарь", "Замшелая конструкция, выглядит как алтарь.", new List<GlobalAction>() { new GlobalAction.Visit("SP0001"), new GlobalAction.Relocation("PT0002") }));
            _AllPlacesID.Add(new Place("PT0002", "Тропа", "Вы шли по тропе, в какой-то момент времени вы замечаете множество маленьких следов идущих парарельно вам", new List<GlobalAction>() { new GlobalAction.Relocation("PT0003") }));
            _AllPlacesID.Add(new Place("PT0002", "Разрушенная деревня", "Полуразрушенная деревня, очевидно, тут давно нет людей.", new List<GlobalAction>() { new GlobalAction.Visit("SP0002"), new GlobalAction.Visit("SP0003"), new GlobalAction.Fight(new List<string>() { "E00001" }, "SP0004") }));
        }

        public static Spot GetSpotPerID(string ID)
        {
            foreach (var spot in _AllSpotsID)
                if (spot.ID == ID)
                    return spot;

            throw new Exception("Wrong ID");
        }

        public static Place GetPlacePerID(string ID)
        {
            foreach (var place in _AllPlacesID)
                if (place.ID == ID)
                    return place;

            throw new Exception("Wrong ID");
        }
    }
}
