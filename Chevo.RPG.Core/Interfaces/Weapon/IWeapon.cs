using Chevo.RPG.Core.Enum;
using Chevo.RPG.Core.Interfaces.Actor;


namespace Chevo.RPG.Core.Interfaces.Weapon
{
    public interface IWeapon
    {
        void Attack(IActor attacker, Direction direction);
    }
}
