using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using Chevo.RPG.WebApp.Core.Interfaces.Weapon;

namespace Chevo.RPG.WebApp.Core.Interfaces.Inventory
{
    public interface IWeaponItem: IItem
    {
        IWeapon Equip(IActor owner);

        void Unequip();

        bool Equipped { get; }
    }
}
