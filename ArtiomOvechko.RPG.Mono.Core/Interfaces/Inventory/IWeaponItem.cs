using ArtiomOvechko.RPG.Mono.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Weapon;

namespace ArtiomOvechko.RPG.Mono.Core.Interfaces.Inventory
{
    public interface IWeaponItem: IItem
    {
        IWeapon Equip(IActor owner);

        void Unequip();

        bool Equipped { get; }
    }
}
