using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    abstract class ShortSword : Weapon
    {
        ShortSword()
        {
            damage = new Die(DieType.D6);
            name = "ShortSword";
            range = 0;
            //TODO set weapon type = martial
        }
    }
}