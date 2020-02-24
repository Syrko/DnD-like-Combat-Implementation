using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    class Die
    {
        private static readonly Dictionary<string, int> Ranges = new Dictionary<string, int>()
        {
            { DieType.D4, 4 },
            { DieType.D6, 6 },
            { DieType.D8, 8 },
            { DieType.D10, 10 },
            { DieType.D12, 12 },
            { DieType.D20, 20 },
            { DieType.D100, 10 }
        };
        private static Random rand = new Random();

        private int range;
        private string type;

        public int Range { get => range; }
        public string Type { get => type; }

        public Die(string Type)
        {
            this.type = Type;
            this.range = Die.Ranges[Type];
        }

        public int RollDie()
        {
            int result = rand.Next(1, range);
            
            if(type == DieType.D100)
                result *= 10;

            return result;
        }
    }

    struct DieType
    {
        public const string D4 = "D4";
        public const string D6 = "D6";
        public const string D8 = "D8";
        public const string D10 = "D10";
        public const string D12 = "D12";
        public const string D20 = "D20";
        public const string D100 = "D100";
    }
}
