using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyKingdom
{
    public class Elementary
    {
        public class ElementaryElements
        {
            public float Physical { get; private set; }
            public float Fiery { get; private set; }
            public float Ice { get; private set; }
            public float Dark { get; private set; }
            public float Holy { get; private set; }
            public ElementaryElements(float physical, float fiery, float ice, float dark, float holy)
            {
                this.Physical = physical;
                this.Fiery = fiery;
                this.Ice = ice;
                this.Dark = dark;
                this.Holy = holy;
            }
            public override string ToString()
            {
                return $"Физический {Physical}, Огненый {Fiery}, Ледяной {Ice}, Демонический {Dark}, Святой {Holy}";
            }
            public static ElementaryElements GetSubtractionElementaryElements(ElementaryElements firstElementaryElements, ElementaryElements secondElementaryElements)
            {
                float _tempPhysical = (firstElementaryElements.Physical - secondElementaryElements.Physical) < 0 ? 0f : firstElementaryElements.Physical - secondElementaryElements.Physical;
                float _tempFiery = (firstElementaryElements.Fiery - secondElementaryElements.Fiery) < 0 ? 0f : firstElementaryElements.Fiery - secondElementaryElements.Fiery;
                float _tempIce = (firstElementaryElements.Ice - secondElementaryElements.Ice) < 0 ? 0f : firstElementaryElements.Ice - secondElementaryElements.Ice;
                float _tempDark = (firstElementaryElements.Dark - secondElementaryElements.Dark) < 0 ? 0f : firstElementaryElements.Dark - secondElementaryElements.Dark;
                float _tempHoly = (firstElementaryElements.Holy - secondElementaryElements.Holy) < 0 ? 0f : firstElementaryElements.Holy - secondElementaryElements.Holy;

                return new ElementaryElements(_tempPhysical, _tempFiery, _tempIce, _tempDark, _tempHoly);
            }
            public static float GetSumOfElementaryElements(ElementaryElements elementaryElements) => elementaryElements.Physical + elementaryElements.Fiery + elementaryElements.Ice + elementaryElements.Dark + elementaryElements.Holy;
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

                        isLVLUp = _tempLVL < _tempNewLVL;
                        break;
                    case StatTypes.Dexterity:
                        _tempLVL = (int)Math.Truncate(Dexterity);
                        Dexterity = (float)(gainedExperience / (Math.Pow(100, _tempLVL) * ChangeFactors[((int)statType)]));

                        _tempNewLVL = (int)Math.Truncate(Dexterity);

                        isLVLUp = _tempLVL < _tempNewLVL;
                        break;
                    case StatTypes.Wisdom:
                        _tempLVL = (int)Math.Truncate(Wisdom);
                        Wisdom = (float)(gainedExperience / (Math.Pow(100, _tempLVL) * ChangeFactors[((int)statType)]));

                        _tempNewLVL = (int)Math.Truncate(Wisdom);

                        isLVLUp = _tempLVL < _tempNewLVL;
                        break;
                    case StatTypes.Intelligence:
                        _tempLVL = (int)Math.Truncate(Intelligence);
                        Intelligence = (float)(gainedExperience / (Math.Pow(100, _tempLVL) * ChangeFactors[((int)statType)]));

                        _tempNewLVL = (int)Math.Truncate(Intelligence);

                        isLVLUp = _tempLVL < _tempNewLVL;
                        break;
                    case StatTypes.Charisma:
                        _tempLVL = (int)Math.Truncate(Charisma);
                        Charisma = (float)(gainedExperience / (Math.Pow(100, _tempLVL) * ChangeFactors[((int)statType)]));

                        _tempNewLVL = (int)Math.Truncate(Charisma);

                        isLVLUp = _tempLVL < _tempNewLVL;
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
}
