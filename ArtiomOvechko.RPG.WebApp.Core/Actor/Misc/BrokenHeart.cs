using Chevo.RPG.WebApp.Core.Animation;
using Chevo.RPG.WebApp.Core.Collision;
using Chevo.RPG.WebApp.Core.Environment;
using Chevo.RPG.WebApp.Core.Stats;


namespace Chevo.RPG.WebApp.Core.Actor
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
