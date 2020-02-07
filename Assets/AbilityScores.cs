using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    class AbilityScores
    {
        private int strength;
        private int dexterity;
        private int constitution;
        private int intelligence;
        private int wisdom;
        private int charisma;

        public int Strength { get => strength; set => strength = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int Constitution { get => constitution; set => constitution = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }
        public int Wisdom { get => wisdom; set => wisdom = value; }
        public int Charisma { get => charisma; set => charisma = value; }
    }
}
