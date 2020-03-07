using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    public class Armor : Equipment
    {
        private int acBonus;
        private string name;
        private bool stealthDisadvantage;
        private string type;
        private int strengthRequirement;
        private int maxDexterity;

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