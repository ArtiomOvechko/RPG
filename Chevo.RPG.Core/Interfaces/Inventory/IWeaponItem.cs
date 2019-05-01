using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Core.Interfaces.Weapon;

namespace Chevo.RPG.Core.Interfaces.Inventory
{
    public interface IWeaponItem: IItem
    {
        IWeapon Equip(IActor owner);

        void Unequip();

        bool Equipped { get; }
    }
}
