using Chevo.RPG.WebApp.Core.Stats;
using Chevo.RPG.WebApp.Core.Weapon;

using System;


namespace Chevo.RPG.WebApp.Core.Inventory.Weapon
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
