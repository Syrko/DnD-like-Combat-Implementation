using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    public abstract class Weapon : Equipment
    {
        private int damage;
        private int spdFactorModifier;
        private string name;    //TODO change diagram -- fix name in diagram
        private int range;
        private string type;    // TODO change diagram -- change type

        public int RollForAttack()
        {
            
        }
    }
}