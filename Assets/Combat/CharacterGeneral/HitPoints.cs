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

        public void Rest()
        {
            currentHP = maxHP;
            tempHP = 0;
        }

        // TODO change in diagram
        public bool CheckForDeath()
        {
            return currentHP <= 0;
        }
    }
}
