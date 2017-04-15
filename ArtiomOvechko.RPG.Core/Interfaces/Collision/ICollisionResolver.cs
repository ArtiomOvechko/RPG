using ArtiomOvechko.RPG.Core.Enum;
using ArtiomOvechko.RPG.Core.Interfaces.Actor;


namespace ArtiomOvechko.RPG.Core.Interfaces.Collision
{
    public interface ICollisionResolver
    {
        int ResolveCollision(IActor sender, Direction direction);
    }
}
