using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    abstract class Weapon : Equipment
    {
        private int damage;
        private int spdFactorModifier;
        private string name; //TODO fix name in diagram
        private int range;
        private WeaponType type;
    }
}