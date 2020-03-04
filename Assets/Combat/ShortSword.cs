using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    class ShortSword : Weapon
    {
        ShortSword()
        {
            Die damage = new Die(DieType.D6);
            string name = "ShortSword";
            int range = 0;
            //TODO set weapon type = martial
        }
    }
}