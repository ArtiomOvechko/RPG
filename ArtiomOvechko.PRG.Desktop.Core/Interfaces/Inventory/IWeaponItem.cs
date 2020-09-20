using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Weapon;

namespace ArtiomOvechko.RPG.Desktop.Core.Interfaces.Inventory
{
    public interface IWeaponItem: IItem
    {
        IWeapon Equip(IActor owner);

        void Unequip();

        bool Equipped { get; }
    }
}
