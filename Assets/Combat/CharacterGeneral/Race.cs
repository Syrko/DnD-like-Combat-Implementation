using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    abstract class Race
    {
        private string name;
        private Dictionary<string, int> abilityScoreIncrease;
        private Dictionary<string, int> abilityScoreDecrease;
        private int speed;
        private List<string> languages;

        public string Name { get => name; set => name = value; }
        public Dictionary<string, int> AbilityScoreIncrease { get => abilityScoreIncrease; set => abilityScoreIncrease = value; }
        public Dictionary<string, int> AbilityScoreDecrease { get => abilityScoreDecrease; set => abilityScoreDecrease = value; }
        public int Speed { get => speed; set => speed = value; }
        public List<string> Languages { get => languages; set => languages = value; }
    }
}
