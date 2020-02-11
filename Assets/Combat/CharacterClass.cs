using System;
using System.Collections.Generic;

namespace Combat
{
    class CharacterClass
    {
        private static readonly List<DndClass> Classes = new List<DndClass>()
        {
            new DndClass("Fighter", DieType.D10),
            new DndClass("Rogue", DieType.D8)
        };

        private int level;
        private string name;
        private Die hitDie;
        private List<int> proficiencies;
        private List<int> features;

        public CharacterClass(int level, string name, Die hitDie, List<int> proficiencies, List<int> features)
        {
            this.level = level;
            this.name = name;
            this.hitDie = hitDie;
            this.proficiencies = proficiencies;
            this.features = features;
        }

        public int Level { get => level; }
        public string Name { get => name; }
        public Die HitDie { get => hitDie; }
        public List<int> Proficiencies { get => proficiencies; }
        public List<int> Features { get => features; }
        
        public void LevelUp() { level++; }
        public void AddProficiency(int newProficiency) { proficiencies.Add(newProficiency); }
        public void AddFeature(int newFeature) { features.Add(newFeature); }
    }

    struct DndClass
    {
        public string Name { get; }
        public string HitDie { get; }

        public DndClass(string Name, string HitDie)
        {
            this.Name = Name;
            this.HitDie = HitDie;
        }
    }
}
