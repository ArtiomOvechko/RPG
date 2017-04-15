using Chevo.RPG.Core.Stats;
using Chevo.RPG.Core.Weapon;

using System;


namespace Chevo.RPG.Core.Inventory.Weapon
{
    public class KnifeWeaponItem: BaseWeaponItem
    {
        public KnifeWeaponItem(Point point): base(point)
        {
            Title = Common.Settings.ItemSettings.KnifeTitle;
            Animation = new Uri(Common.Settings.ItemSettings.KnifeAnimation);

            _weapon = new Knife();
        }
    }
}
