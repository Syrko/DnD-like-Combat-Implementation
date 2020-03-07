using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    public abstract class Weapon : Equipment
    {
        // TODO change diagram -- update class
        private Die dieDamage;
        private int numberOfDice; 
        private string name;    //TODO change diagram -- fix name in diagram
        private int range;
        private bool isMartial;    // TODO change diagram -- change type
        private bool isVersatile;

        // TODO change diagram -- change access modifier
        internal int NumberOfDice { get => numberOfDice; set => numberOfDice = value; }
        internal string Name { get => name; set => name = value; }
        internal int Range { get => range; set => range = value; }
        internal bool IsMartial { get => isMartial; set => isMartial = value; }
        internal bool IsVersatile { get => isVersatile; set => isVersatile = value; }
        internal Die DieDamage { get => dieDamage; set => dieDamage = value; }
    }
}