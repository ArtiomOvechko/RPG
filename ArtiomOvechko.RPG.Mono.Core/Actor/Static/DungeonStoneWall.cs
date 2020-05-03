using ArtiomOvechko.RPG.Mono.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Mono.Core.Animation;
using ArtiomOvechko.RPG.Mono.Core.Stats;
using ArtiomOvechko.RPG.Mono.Core.Collision;
using ArtiomOvechko.RPG.Mono.Core.Environment;


namespace ArtiomOvechko.RPG.Mono.Core.Actor
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
