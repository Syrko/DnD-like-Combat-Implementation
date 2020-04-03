using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    /// <summary>
    /// Parent class for all the armors of the game.
    /// Every individual armor type inherits and can be cast to and from this class.
    /// </summary>
    public class Armor
    {
        private int acBonus;
        private string name;
        private bool stealthDisadvantage;
        private string type;
        private int strengthRequirement;
        private int maxDexterity;

        // Simple constructor for the armor class. Typically used when loading an armor piece from the database.
        // After creating the Armor object it can be cast to another class inheriting from Armor.
        internal Armor(int acBonus, string name, bool stealthDisadvantage, string type, int strengthRequirement, int maxDexterity)
        {
            this.acBonus = acBonus;
            this.name = name;
            this.stealthDisadvantage = stealthDisadvantage;
            this.type = type;
            this.strengthRequirement = strengthRequirement;
            this.maxDexterity = maxDexterity;
        }

        internal int AcBonus { get => acBonus; }
        internal string Name { get => name; }
        internal bool StealthDisadvantage { get => stealthDisadvantage; }
        internal string Type { get => type; }
        internal int StrengthRequirement { get => strengthRequirement; }
        internal int MaxDexterity { get => maxDexterity; }
    }
}