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
        public int CurrentHP { get => currentHP; set => currentHP = value; }
        public int TempHP { get => tempHP; set => tempHP = value; }

        public void takeDamage(int damage)
        {
            if (TempHP == 0)
            {
                CurrentHP -= damage;
            }
            else if (TempHP > damage)
            {
                TempHP -= damage;
            }
            else
            {
                damage -= TempHP;
                TempHP = 0;
                CurrentHP -= damage;
            }
            
        }

        public void heal(int healAmount)
        {
            if (CurrentHP != maxHP)
            {
                CurrentHP += healAmount;
            }
        }
    }
}
