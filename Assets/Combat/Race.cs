﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    abstract class Race
    {
        private string name;
        private Dictionary<string, int> abilityScoreIncrease; // TODO change diagram -- change key type
        private Dictionary<string, int> abilityScoreDecrease;
        private int speed;
        private List<string> languages;
    }
}
