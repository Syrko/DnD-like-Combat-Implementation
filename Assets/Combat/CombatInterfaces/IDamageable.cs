using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    interface IDamageable
    {
        void Damage(int amount);
        void Heal(int amount);
    }
}
