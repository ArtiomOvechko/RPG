using ArtiomOvechko.RPG.Mono.Core.Stats;
using ArtiomOvechko.RPG.Mono.Core.Weapon;

using System;


namespace ArtiomOvechko.RPG.Mono.Core.Inventory.Weapon
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
