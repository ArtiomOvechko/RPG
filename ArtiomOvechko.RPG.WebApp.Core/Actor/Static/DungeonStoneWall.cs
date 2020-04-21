using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using Chevo.RPG.WebApp.Core.Animation;
using Chevo.RPG.WebApp.Core.Stats;
using Chevo.RPG.WebApp.Core.Collision;
using Chevo.RPG.WebApp.Core.Environment;


namespace Chevo.RPG.WebApp.Core.Actor
{
    public class DungeonStoneWall: BaseActor
    {
        public DungeonStoneWall(Point initialPosition, IEnvironmentContainer environmentContainer) 
            : base(null, initialPosition, environmentContainer)
        {
            Stats = new DefaultStats(Common.Settings.ActorSettings.DefaultSize, 0, 0, 0);
            _animation = new DungeonStoneWallAnimation();
            _collisionResolver = new IgnoringCollisionResolver(this);
        }
    }
}
