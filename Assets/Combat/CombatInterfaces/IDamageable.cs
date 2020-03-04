using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    interface IDamageable
    {
        // TODO change diagram -- Remove hp param
        public void Damage(int amount);
        public void Heal(int amount);
    }
}
