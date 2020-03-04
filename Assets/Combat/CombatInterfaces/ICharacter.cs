using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    interface ICharacter
    {
        public void LevelUp();
        public void Move(int distance);
        public void UseSkill();
        public void Attack(Weapon weapon, Character target);
        public void CastSpell();
    }
}
