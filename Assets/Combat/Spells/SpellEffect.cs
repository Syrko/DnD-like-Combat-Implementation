using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    class SpellEffect
    {
        private string type;
        private string amount;

        public SpellEffect(string type, string amount)
        {
            this.type = type;
            this.amount = amount;
        }

        public string Type { get => type;}
        public string Amount { get => amount;}
    }
}
