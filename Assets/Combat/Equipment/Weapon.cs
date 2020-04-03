using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    /// <summary>
    /// Parent class for all the weapons of the game.
    /// Every individual weapon type inherits and can be cast to and from this class.
    /// </summary>
    public class Weapon
    {
        private Die dieDamage;
        private int numberOfDice; 
        private string name;
        private int range;
        private bool isMartial;
        private bool isFinesse;

        // Simple constructor for the weapon class. Typically used when loading a weapon from the database.
        // After creating the Weapon object it can be cast to another class inheriting from Weapon.
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