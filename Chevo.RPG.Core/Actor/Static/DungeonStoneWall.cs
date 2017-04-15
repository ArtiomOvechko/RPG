using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Core.Animation;
using Chevo.RPG.Core.Stats;
using Chevo.RPG.Core.Collision;

namespace Chevo.RPG.Core.Actor
{
    public class DungeonStoneWall: BaseActor, IActor
    {
        public DungeonStoneWall(Point initialPosition) : base(null, initialPosition)
        {
            Stats = new DefaultStats(Common.Settings.ActorSettings.DefaultSize, 0, 0, 0);
            _animation = new DungeonStoneWallAnimation();
            _collisionResolver = new IgnoringCollisionResolver(this);
        }
    }
}
