using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    /// <summary>
    /// Interface to be implemented by classes for objects that can be damaged.
    /// </summary>
    interface IDamageable
    {
        void Damage(int amount);
        void Heal(int amount);
    }
}
