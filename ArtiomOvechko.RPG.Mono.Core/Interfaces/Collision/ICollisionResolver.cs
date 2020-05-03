using ArtiomOvechko.RPG.Mono.Core.Enum;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Actor;

namespace ArtiomOvechko.RPG.Mono.Core.Interfaces.Collision
{
    public interface ICollisionResolver
    {
        int ResolveCollision(Direction direction);

        void HandleAttack(IStats attackerStats);
    }
}
