using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    /// <summary>
    /// Class that holds the necessary information for the races
    /// </summary>
    abstract class Race
    {
        // Name of the race (e.g Elf, Human)
        private string name;

        // Entries for the skills the race has advantage or disadvantages
        private Dictionary<string, int> abilityScoreIncrease;
        private Dictionary<string, int> abilityScoreDecrease;

        // Speed of the race in feet
        private double speed;
        // Languages the race is fluent in
        private List<string> languages;

        public string Name { get => name; set => name = value; }
        public Dictionary<string, int> AbilityScoreIncrease { get => abilityScoreIncrease; set => abilityScoreIncrease = value; }
        public Dictionary<string, int> AbilityScoreDecrease { get => abilityScoreDecrease; set => abilityScoreDecrease = value; }
        public double Speed { get => speed; set => speed = value; }
        public List<string> Languages { get => languages; set => languages = value; }
    }
}
