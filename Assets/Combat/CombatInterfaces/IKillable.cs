using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    /// <summary>
    /// Interface to be implemented by classes for objects that can die.
    /// </summary>
    interface IKillable
    {
        void Die();
        bool CheckForDeath(); // TODO add to diagram
    }
}
