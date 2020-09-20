using ArtiomOvechko.RPG.Desktop.Core.Enum;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Actor;

namespace ArtiomOvechko.RPG.Desktop.Core.Interfaces.Collision
{
    public interface ICollisionResolver
    {
        int ResolveCollision(Direction direction);

        void HandleAttack(IStats attackerStats);
    }
}
