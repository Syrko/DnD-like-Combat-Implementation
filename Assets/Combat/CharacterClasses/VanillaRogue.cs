﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    class VanillaRogue : Rogue
    {
        internal VanillaRogue()
        {
            name = "Rogue";
            hitDie = new Die(DieType.D8);
            this.level = 1;
            this.Speed = 10;
        }
    }
}
