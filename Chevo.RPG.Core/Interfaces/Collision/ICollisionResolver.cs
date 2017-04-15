using Chevo.RPG.Core.Enum;
using Chevo.RPG.Core.Interfaces.Actor;

namespace Chevo.RPG.Core.Interfaces.Collision
{
    public interface ICollisionResolver
    {
        int ResolveCollision(Direction direction);

        void HandleAttack(IStats attackerStats);
    }
}
