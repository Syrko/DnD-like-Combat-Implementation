using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    abstract class Class // Hmmm this class appears to be made out of class
    {
        protected int level;
        protected string name;
        protected Die hitDie;
        protected SavingThrows savingThrows;

        public void LevelUp()
        {
            try
            {
                level++;
            }
            catch(Exception e)
            {
                Debug.Log("During leveling up: " + e.Message);
            }
        }
    }

    struct Alignment
    {
        public const string LawfulGood = "Lawful Good";
        public const string NeutralGood = "Neutral Good";
        public const string ChaoticGood = "Chaotic Good";
        public const string LawfulNeutral = "Lawful Neutral";
        public const string Neutral = "Neutral";
        public const string ChaoticNeutral = "Chaotic Neutral";
        public const string LawfulEvil = "Lawful Evil";
        public const string NeutralEvil = "Neutral Evil";
        public const string ChaoticEvil = "Chaotic Evil";
    }
}
