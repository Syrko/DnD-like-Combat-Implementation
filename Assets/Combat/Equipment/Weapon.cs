﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    public class Weapon : Equipment
    {
        // TODO change diagram -- update class
        private Die dieDamage;
        private int numberOfDice; 
        private string name;    //TODO change diagram -- fix name in diagram
        private int range;
        private bool isMartial;    // TODO change diagram -- change type
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

        // TODO change diagram -- change access modifier
        internal int NumberOfDice { get => numberOfDice; }
        internal string Name { get => name; }
        internal int Range { get => range; }
        internal bool IsMartial { get => isMartial; }
        internal bool IsFinesse { get => isFinesse; }
        internal Die DieDamage { get => dieDamage; }
    }
}