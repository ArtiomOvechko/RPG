using ArtiomOvechko.RPG.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Core.Interfaces.Interaction;

namespace ArtiomOvechko.RPG.Core.Interfaces.Weapon
{
    public interface IWeapon
    {
        IBehavior Projectile(IActor creator);
    }
}
