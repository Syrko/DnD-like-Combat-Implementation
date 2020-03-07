﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Combat;

namespace Assets.Combat.Armors
{
    class Breastplate : Armor
    {
        public Breastplate(int acBonus, string name, bool stealthDisadvantage, string type, int strengthRequirement, int maxDexterity)
            : base(acBonus, name, stealthDisadvantage, type, strengthRequirement, maxDexterity)
        {

        }
    }
}
