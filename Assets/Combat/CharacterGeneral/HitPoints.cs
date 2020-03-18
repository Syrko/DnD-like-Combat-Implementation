using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    public class HitPoints
    {
        private int maxHP;
        private int currentHP;
        private int tempHP;

        public int MaxHP { get => maxHP; set => maxHP = value; }
        public int CurrentHP { get => currentHP; }
        public int TempHP { get => tempHP; set => tempHP = value; }

        /// <summary>
        /// Subtract hitpoins from the current and temp pool
        /// </summary>
        /// <param name="amount">Amount of damage taken</param>
        public void Damage(int amount)
        {
            if (tempHP == 0)
            {
                currentHP -= amount;
            }
            else if (tempHP > amount)
            {
                tempHP -= amount;
            }
            else
            {
                amount -= tempHP;
                tempHP = 0;
                currentHP -= amount;
            }
        }

        /// <summary>
        /// Add hitpoins to the current pool
        /// </summary>
        /// <param name="amount">Amount of healing</param>
        public void Heal(int amount)
        {
            int missingHP = maxHP - currentHP;
            if (missingHP > 0) {
                if (missingHP >= amount)
                {
                    currentHP += amount;
                }
                else
                {
                    currentHP = maxHP;
                }
            }
        }

        /// <summary>
        /// Reseting the current and temp hp pools
        /// </summary>
        public void Rest()
        {
            currentHP = maxHP;
            tempHP = 0;
        }

        // TODO change in diagram
        /// <summary>
        /// Checks if the character is dead
        /// </summary>
        /// <returns>Returns if the current is dead according to the currenthp</returns>
        public bool CheckForDeath()
        {
            return currentHP <= 0;
        }
    }
}
