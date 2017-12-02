using Chevo.RPG.Core.Animation;
using Chevo.RPG.Core.Collision;
using Chevo.RPG.Core.Stats;


namespace Chevo.RPG.Core.Actor
{
    public class BrokenHeart: BaseActor
    {
        public BrokenHeart(Point initialPosition) : base(null, initialPosition)
        {
            Stats = new DefaultStats(Common.Settings.ActorSettings.DefaultSize, 1, 3, Common.Settings.ActorSettings.BrokenHeartStepLength);
            _animation = new HeartAnimation();
            _collisionResolver = new IgnoringCollisionResolver(this);
        }
    }
}
