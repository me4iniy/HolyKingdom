﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HolyKingdom
{
    public class Person
    {
        public string Name { get; private set; }
        public float HP { get; private set; }// heals points
        public float MP { get; private set; }// mana points
        public float SP { get; private set; }// stamina points
        public Stats Stats { get; private set; } // not encapsulation 

        public Person(float HP, float MP, float SP, Stats stats, string name)
        {
            this.HP = HP;
            this.MP = MP;
            this.Stats = stats;
            this.Name = name;
            this.SP = SP;
        }
        public void TakeDamage(float damage, out bool isDead)
        {
            HP -= damage;

            isDead = (HP < 0) ? true : false;
        }
        public void TrySpendingMana(float manaUsed, out bool isSpend)
        {
            if (MP - manaUsed > 0)
                MP -= manaUsed;

            isSpend = (MP < 0) ? true : false;
        }
        public void TrySpendingStamina(float staminaUsed, out bool isSpend)
        {
            if (SP - staminaUsed > 0)
                SP -= staminaUsed;

            isSpend = (SP < 0) ? true : false;
        }
    }
    public class Stats
    {
        public enum StatTypes { Strength, Dexterity, Wisdom, Intelligence, Charisma }
        public float Strength { get; private set; }
        public float Dexterity { get; private set; }
        public float Wisdom { get; private set; }
        public float Intelligence { get; private set; }
        public float Charisma { get; private set; }

        private readonly float[] ChangeFactors;//multiply experience for stats
        public Stats(float strength, float dexterity, float wisdom, float intelligence, float charisma, float[] changeFactors)
        {
            Strength = strength;
            Dexterity = dexterity;
            Wisdom = wisdom;
            Intelligence = intelligence;
            Charisma = charisma;

            if (changeFactors.Length > 5)
                throw new ArgumentOutOfRangeException($"{changeFactors.Length} > 5, it's imposible");

            ChangeFactors = changeFactors;
        }
        public void UpgradeStat(float gainedExperience, StatTypes statType, out bool isLVLUp)//100 exp = 1 lvl, 200 exp = 2 lvl, 400 exp = 3 lvl
        {
            //One of stats upgraded on "exp / ((100 ^ actual LVL) * change factor)"

            int _tempLVL = 0;
            int _tempNewLVL = 0;

            switch (statType)
            {
                case StatTypes.Strength:
                    _tempLVL = (int)Math.Truncate(Strength);
                    Strength = (float)(gainedExperience / (Math.Pow(100, _tempLVL) * ChangeFactors[((int)statType)]));

                    _tempNewLVL = (int)Math.Truncate(Strength);

                    if (_tempLVL < _tempNewLVL)
                        isLVLUp = true;
                    else
                        isLVLUp = false;
                    break;
                case StatTypes.Dexterity:
                    _tempLVL = (int)Math.Truncate(Dexterity);
                    Dexterity = (float)(gainedExperience / (Math.Pow(100, _tempLVL) * ChangeFactors[((int)statType)]));

                    _tempNewLVL = (int)Math.Truncate(Dexterity);

                    if (_tempLVL < _tempNewLVL)
                        isLVLUp = true;
                    else
                        isLVLUp = false;
                    break;
                case StatTypes.Wisdom:
                    _tempLVL = (int)Math.Truncate(Wisdom);
                    Wisdom = (float)(gainedExperience / (Math.Pow(100, _tempLVL) * ChangeFactors[((int)statType)]));

                    _tempNewLVL = (int)Math.Truncate(Wisdom);

                    if (_tempLVL < _tempNewLVL)
                        isLVLUp = true;
                    else
                        isLVLUp = false;
                    break;
                case StatTypes.Intelligence:
                    _tempLVL = (int)Math.Truncate(Intelligence);
                    Intelligence = (float)(gainedExperience / (Math.Pow(100, _tempLVL) * ChangeFactors[((int)statType)]));

                    _tempNewLVL = (int)Math.Truncate(Intelligence);

                    if (_tempLVL < _tempNewLVL)
                        isLVLUp = true;
                    else
                        isLVLUp = false;
                    break;
                case StatTypes.Charisma:
                    _tempLVL = (int)Math.Truncate(Charisma);
                    Charisma = (float)(gainedExperience / (Math.Pow(100, _tempLVL) * ChangeFactors[((int)statType)]));

                    _tempNewLVL = (int)Math.Truncate(Charisma);

                    if (_tempLVL < _tempNewLVL)
                        isLVLUp = true;
                    else
                        isLVLUp = false;
                    break;
                default:
                    isLVLUp = false;
                    break;
            }
        }
        public override string ToString() => $"Стамина - {Strength}, Ловкость - {Dexterity}" +
                                             $", Мудрость - {Wisdom}, Интелект - {Intelligence}" +
                                             $", Харизма - {Charisma}";
    }
}
