using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Combat
{
    /// <summary>
    /// Skeletal implementation of the equipment class.
    /// TODO Improve and expand its functionality
    /// </summary>
    public class Equipment
    {
        private List<Weapon> weaponList;
        private List<Armor> armorList;
        private List<Item> itemList;

        public List<Weapon> WeaponList { get => weaponList; set => weaponList = value; }
        public List<Armor> ArmorList { get => armorList; set => armorList = value; }
        internal List<Item> ItemList { get => itemList; set => itemList = value; }
    }
}
