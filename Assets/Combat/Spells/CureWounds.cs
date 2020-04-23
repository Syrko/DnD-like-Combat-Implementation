using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat.Spells
{
    class CureWounds : Spell, ICastable
    {
        public CureWounds()
        {
            this.Name = "Cure Wounds";
            this.Level = 1;
            this.Range = 0;
            this.School = "evocation";
            this.SavingThrow = "none";
            this.Duration = "instantaneous";
            this.AttackType = "touch";
            this.CastingTime = "1 action";
            this.Components = new List<string>()
            {
                "Verbal",
                "Somatic"
            };
            this.Effect = new SpellEffect("Heal", DieType.D8);
        }

        public void Cast(List<Character> Targets)
        {
            foreach(Character target in Targets)
            {
                int value = new Die(Effect.Amount).RollDie();
                target.Heal(value);
                CombatLog.AddMessageToQueue(target.CharacterName + " was healed for " + value + " hitpoints!");
            }
        }
    }
}
