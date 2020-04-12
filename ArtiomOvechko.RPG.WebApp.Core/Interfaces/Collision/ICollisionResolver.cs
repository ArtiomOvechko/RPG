using Chevo.RPG.WebApp.Core.Enum;
using Chevo.RPG.WebApp.Core.Interfaces.Actor;

namespace Chevo.RPG.WebApp.Core.Interfaces.Collision
{
    public interface ICollisionResolver
    {
        int ResolveCollision(Direction direction);

        void HandleAttack(IStats attackerStats);
    }
}
