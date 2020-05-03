using ArtiomOvechko.RPG.Mono.Core.Animation;
using ArtiomOvechko.RPG.Mono.Core.Collision;
using ArtiomOvechko.RPG.Mono.Core.Environment;
using ArtiomOvechko.RPG.Mono.Core.Stats;


namespace ArtiomOvechko.RPG.Mono.Core.Actor
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
