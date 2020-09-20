using ArtiomOvechko.RPG.Desktop.Core.Animation;
using ArtiomOvechko.RPG.Desktop.Core.Collision;
using ArtiomOvechko.RPG.Desktop.Core.Environment;
using ArtiomOvechko.RPG.Desktop.Core.Stats;


namespace ArtiomOvechko.RPG.Desktop.Core.Actor
{
    public class BrokenHeart: BaseActor
    {
        public BrokenHeart(Point initialPosition, IEnvironmentContainer environmentContainer) 
            : base(null, initialPosition, environmentContainer)
        {
            Stats = new DefaultStats(Common.Settings.ActorSettings.DefaultSize, 1, 3, Common.Settings.ActorSettings.BrokenHeartStepLength);
            _animation = new HeartAnimation();
            _collisionResolver = new IgnoringCollisionResolver(this);
        }
    }
}
