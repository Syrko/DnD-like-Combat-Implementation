﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat.Weapons
{
    class Shortbow : Weapon
    {
        public Shortbow(Die dieDamage, int numberOfDice, string name, int range, bool isMartial, bool isFinesse)
            : base(dieDamage, numberOfDice, name, range, isMartial, isFinesse)
        {

        }
    }
}
