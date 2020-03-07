﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat.Weapons
{
    class Warhammer : Weapon
    {
        public Warhammer(Die dieDamage, int numberOfDice, string name, int range, bool isMartial, bool isFinesse)
            : base(dieDamage, numberOfDice, name, range, isMartial, isFinesse)
        {

        }
    }
}
