using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    class HitPoints
    {
        private int maxHP;
        private int currentHP;
        private int tempHP;

        public int MaxHP { get => maxHP; set => maxHP = value; }
        public int CurrentHP { get => currentHP;}
        public int TempHP { get => tempHP; set => tempHP = value; }

        public void TakeDamage(int damage)
        {
            if (tempHP == 0)
            {
                currentHP -= damage;
            }
            else if (tempHP > damage)
            {
                tempHP -= damage;
            }
            else
            {
                damage -= tempHP;
                tempHP = 0;
                currentHP -= damage;
            }
            
        }

        public void Heal(int healAmount)
        {
            int missingHP = maxHP - currentHP;
            if (missingHP > 0) {
                if (missingHP >= healAmount)
                {
                    currentHP += healAmount;
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
    }
}
