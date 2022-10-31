using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace HolyKingdom
{
    public class Item
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public float Price { get; private set; }
        public float Weight { get; private set; }
        public Item(string name, string description, float price, float weight)
        {
            Name = name;
            Description = description;
            Price = price;
            Weight = weight;
        }
        public override string ToString() => $"{Name}";

        public class Armor : Item
        {
            public enum TypesOfArmor { Light, Medium, Heavy }
            public TypesOfArmor TypeOfArmor { get; private set; }
            public float Defense { get; private set; }

            public Armor(TypesOfArmor typeOfArmor, float defense, string name,
                                        string description, float price, float weight)
                                        : base(name, description, price, weight)
            {
                TypeOfArmor = typeOfArmor;
                Defense = defense;
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

                return $"{Name}, это {tempSrtTypeOfArmor}, защита - {Defense}";
            }
        }
        public class Weapon : Item
        {
            public enum TypesOfWeapon { ShortSword, LongSword, Bow, MagicStaff }
            public TypesOfWeapon TypeOfWeapon { get; private set; }
            public float Damage { get; private set; }
            public float AttackSpeed { get; private set; }
            public Weapon(TypesOfWeapon typeOfWeapon, float damage, float attackSpeed,
                                        string name, string description, float price, float weight)
                                        : base(name, description, price, weight)
            {
                TypeOfWeapon = typeOfWeapon;
                Damage = damage;
                AttackSpeed = attackSpeed;
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

                return $"{Name}, это {tempSrtTypeOfWeapon}, урон - {Damage}, скорость атаки - {AttackSpeed}";
            }
        }
        public class Heal : Item
        {
            public float VolumeOfHeal { get; private set; }

            public Heal(float volumeOfHeal,
                        string name, string description, float price, float weight)
                        : base(name, description, price, weight)
            {
                VolumeOfHeal = volumeOfHeal;
            }
            public override string ToString() => $"{Name}, лечит на {VolumeOfHeal}";
        }
        public class Potion : Item
        {
            
        }
    }
}
