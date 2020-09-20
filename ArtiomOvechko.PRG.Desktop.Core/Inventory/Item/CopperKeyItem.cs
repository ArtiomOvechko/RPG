using ArtiomOvechko.RPG.Desktop.Core.Stats;

using System;


namespace ArtiomOvechko.RPG.Desktop.Core.Inventory.Item
{
    public class CopperKeyItem: BaseItem
    {
        public CopperKeyItem(Point position): base(position)
        {
            Animation = new Uri(Common.Settings.ItemSettings.CopperKeyAnimation);
            Title = Common.Settings.ItemSettings.CopperKeyTitle;
        }
    }
}
