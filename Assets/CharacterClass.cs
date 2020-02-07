using System;
using System.Collections.Generic;

namespace Assets
{
    class CharacterClass
    {
        private int level;
        private string name;
        private int id;
        private int hitDie;
        private List<int> proficiencies;
        private List<int> features;

        
        public int Level { get => level; set => level = value; }
        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public int HitDie { get => hitDie; set => hitDie = value; }
        public List<int> Proficiencies { get => proficiencies; set => proficiencies = value; }
        public List<int> Features { get => features; set => features = value; }
    }
}
