using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Desktop.Core.Animation;
using ArtiomOvechko.RPG.Desktop.Core.Stats;
using ArtiomOvechko.RPG.Desktop.Core.Collision;
using ArtiomOvechko.RPG.Desktop.Core.Environment;


namespace ArtiomOvechko.RPG.Desktop.Core.Actor
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
