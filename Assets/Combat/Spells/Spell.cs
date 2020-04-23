using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Combat
{
    abstract class Spell
    {
        private string name;
        private int level;
        private string castingTime;
        private int range;
        private List<string> components;
        private string duration;
        private string school;
        private string savingThrow;
        private string attackType;
        private SpellEffect effect;

        public string Name { get => name; set => name = value; }
        public int Level { get => level; set => level = value; }
        public string CastingTime { get => castingTime; set => castingTime = value; }
        public int Range { get => range; set => range = value; }
        public List<string> Components { get => components; set => components = value; }
        public string Duration { get => duration; set => duration = value; }
        public string School { get => school; set => school = value; }
        public string SavingThrow { get => savingThrow; set => savingThrow = value; }
        public string AttackType { get => attackType; set => attackType = value; }
        public SpellEffect Effect { get => effect; set => effect = value; }
    }
}
