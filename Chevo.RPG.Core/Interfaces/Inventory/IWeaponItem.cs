using Chevo.RPG.Core.Interfaces.Weapon;

namespace Chevo.RPG.Core.Interfaces.Inventory
{
    public interface IWeaponItem: IItem
    {
        IWeapon Equip();

        void Unequip();

        bool Equipped { get; }
    }
}
