
using System.Diagnostics;
using System.Xml.Linq;
using static HolyKingdom.Item.Weapon;
using static System.Net.Mime.MediaTypeNames;

namespace HolyKingdom
{
    public class Item
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public float Price { get; private set; }
        public float Weight { get; private set; }
        public int LVL { get; private set; }
        public string ID { get; private set; }
        public Item(string name, string description, float price, float weight, int LVL, string ID)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Weight = weight;
            this.LVL = LVL;
            this.ID = ID;
        }
        public override string ToString() => $"Предмет - {Name}";

        public class Armor : Item
        {
            public enum TypesOfArmor { Light, Medium, Heavy }
            public TypesOfArmor TypeOfArmor { get; private set; }
            public Elementary.ElementaryElements DefenseElements { get; private set; }

            public Armor(TypesOfArmor typeOfArmor, Elementary.ElementaryElements defenseElements, 
                                        string name, string description, float price, float weight, int LVL, string ID)
                                        : base(name, description, price, weight, LVL, ID)
            {
                this.TypeOfArmor = typeOfArmor;
                this.DefenseElements = defenseElements;
            }
            public override string ToString()
            {

                string tempSrtTypeOfArmor = TypeOfArmor switch
                {
                    TypesOfArmor.Light => "Лёгкая броня",
                    TypesOfArmor.Medium => "Средняя броня",
                    TypesOfArmor.Heavy => "Тяжелая броня",
                    _ => throw new NotImplementedException()
                };

                return $"[Броня] {Name}, это {tempSrtTypeOfArmor}, с защитой - {DefenseElements}";
            }
        }
        public class Weapon : Item
        {
            public enum TypesOfWeapon { ShortSword, LongSword, Bow, MagicStaff }
            public TypesOfWeapon TypeOfWeapon { get; private set; }
            public Elementary.ElementaryElements DamageElements { get; private set; }

            public Weapon(TypesOfWeapon typeOfWeapon, Elementary.ElementaryElements damageElements,
                                        string name, string description, float price, float weight, int LVL, string ID)
                                        : base(name, description, price, weight, LVL, ID)
            {
                this.TypeOfWeapon = typeOfWeapon;
                this.DamageElements = damageElements;
            }
            public override string ToString()
            {

                string tempSrtTypeOfWeapon = TypeOfWeapon switch
                {
                    TypesOfWeapon.ShortSword => "Лёгкая броня",
                    TypesOfWeapon.LongSword => "Средняя броня",
                    TypesOfWeapon.Bow => "Тяжелая броня",
                    TypesOfWeapon.MagicStaff => "Тяжелая броня",
                    _ => throw new NotImplementedException()
                };

                return $"[Оружие] {Name}, это {tempSrtTypeOfWeapon}, урон - {DamageElements}";
            }
        }
        public class Heal : Item
        {
            public float VolumeOfHeal { get; private set; }


            public Heal(float volumeOfHeal,
                        string name, string description, float price, float weight, int LVL, string ID)
                        : base(name, description, price, weight, LVL, ID)
            {
                VolumeOfHeal = volumeOfHeal;
            }
            public override string ToString() => $"[Лечение] {Name}, лечит на {VolumeOfHeal}";
        }
        public class Resource : Item
        {
            public enum TypesOfResource { Wood }
            public TypesOfResource TypeOfResource { get; private set; }
            public Resource(TypesOfResource typeOfResource,
                            string name, string description, float price, float weight, int LVL, string ID)
                            : base(name, description, price, weight, LVL, ID)
            {
                this.TypeOfResource = typeOfResource;
            }

            public override string ToString()
            {

                string tempSrtTypeOfWeapon = TypeOfResource switch
                {
                    TypesOfResource.Wood => "Дерево",
                    _ => throw new NotImplementedException()
                };

                return $"[Ресурс]{Name}, это {TypeOfResource}";
            }

        }
    }
}
