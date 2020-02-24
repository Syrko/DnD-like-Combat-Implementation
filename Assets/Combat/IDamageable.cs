using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    interface IDamageable
    {
        public void Damage(HitPoints hp, int amount);
        public void Heal(HitPoints hp, int amount);
    }
}
