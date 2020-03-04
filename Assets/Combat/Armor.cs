using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    abstract class Armor : Equipment
    {
        private int acBonus;
        private string name;    //TODO change diagram -- fix name in diagram
        private int maxDexterity;
    }
}