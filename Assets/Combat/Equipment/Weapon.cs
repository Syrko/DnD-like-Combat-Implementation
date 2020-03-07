using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    public class Weapon : Equipment
    {
        private Die dieDamage;
        private int numberOfDice; 
        private string name;
        private int range;
        private bool isMartial;
        private bool isFinesse;

        internal Weapon(Die dieDamage, int numberOfDice, string name, int range, bool isMartial, bool isFinesse)
        {
            this.dieDamage = dieDamage;
            this.numberOfDice = numberOfDice;
            this.name = name;
            this.range = range;
            this.isMartial = isMartial;
            this.isFinesse = isFinesse;
        }

        internal int NumberOfDice { get => numberOfDice; }
        internal string Name { get => name; }
        internal int Range { get => range; }
        internal bool IsMartial { get => isMartial; }
        internal bool IsFinesse { get => isFinesse; }
        internal Die DieDamage { get => dieDamage; }
    }
}