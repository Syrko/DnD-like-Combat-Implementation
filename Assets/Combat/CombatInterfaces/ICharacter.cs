using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    interface ICharacter
    {
        void LevelUp();
        // TODO change diagram -- change parameter type for distance
        bool Move(double distance);
        void UseSkill();
        void Attack(Weapon weapon, Character target);
        void CastSpell();
    }
}
