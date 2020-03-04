using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    public abstract class Weapon : Equipment
    {
        // TODO change diagram --  update class
        private Die dieDamage;
        private int numberOfDice; 
        private string name;    //TODO change diagram -- fix name in diagram
        private int range;
        private bool isMartial;    // TODO change diagram -- change type
        private bool isVersatile;

        public int NumberOfDice { get => numberOfDice; set => numberOfDice = value; }
        public string Name { get => name; set => name = value; }
        public int Range { get => range; set => range = value; }
        public bool IsMartial { get => isMartial; set => isMartial = value; }
        public bool IsVersatile { get => isVersatile; set => isVersatile = value; }
        internal Die DieDamage { get => dieDamage; set => dieDamage = value; }
    }
}