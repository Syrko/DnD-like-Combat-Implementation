using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    /// <summary>
    /// Class for the ability scores of the characters
    /// </summary>
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

        /// <summary>
        /// Increases the ability score of the given type
        /// </summary>
        /// <param name="abilityType">RECOMMENDED: Get the type from the AbilityType struct</param>
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

        /// <summary>
        /// Calculates and returns the ability modifier for the given type
        /// </summary>
        /// <param name="abilityType">RECOMMENDED: Get the type from the AbilityType struct</param>
        /// <returns>The ability modifier</returns>
        public int GetAbilityModifier(string abilityType)
        {
            switch (abilityType)
            {
                case AbilityType.Strength:
                    return (strength - 10) / 2;
                case AbilityType.Dexterity:
                    return (dexterity - 10) / 2;
                case AbilityType.Constitution:
                    return (constitution - 10) / 2; ;
                case AbilityType.Intelligence:
                    return (intelligence - 10) / 2;
                case AbilityType.Wisdom:
                    return (wisdom - 10) / 2;
                case AbilityType.Charisma:
                    return (charisma - 10) / 2;
                default:
                    Debug.Log("Could not calculate ability modifier... AbilityType was: " + abilityType);
                    return 0;
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
