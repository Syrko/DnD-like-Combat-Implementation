using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    class AbilityScores
    {
        private int strength;
        private int dexterity;
        private int constitution;
        private int intelligence;
        private int wisdom;
        private int charisma;

        public int Strength { get => strength; set => strength = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int Constitution { get => constitution; set => constitution = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }
        public int Wisdom { get => wisdom; set => wisdom = value; }
        public int Charisma { get => charisma; set => charisma = value; }

        public void Increase(string abilityType)
        {
            switch (abilityType)
            {
                case AbilityType.Strength:
                    strength++;
                    break;
                case AbilityType.Dexterity:
                    dexterity++;
                    break;
                case AbilityType.Constitution:
                    constitution++;
                    break;
                case AbilityType.Intelligence:
                    intelligence++;
                    break;
                case AbilityType.Wisdom:
                    wisdom++;
                    break;
                case AbilityType.Charisma:
                    charisma++;
                    break;
                default:
                    Debug.Log("Could not increase ability score... AbilityType was: " + abilityType);
                    break;
            }
        }
    }

    struct AbilityType
    {
        public const string Strength = "STR";
        public const string Dexterity = "DEX";
        public const string Constitution = "CON";
        public const string Intelligence = "INT";
        public const string Wisdom = "WIS";
        public const string Charisma = "CHA";
    }
}
