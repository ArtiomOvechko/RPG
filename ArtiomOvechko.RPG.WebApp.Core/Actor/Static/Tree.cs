using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using Chevo.RPG.WebApp.Core.Animation;
using Chevo.RPG.WebApp.Core.Stats;
using Chevo.RPG.WebApp.Core.Collision;


namespace Chevo.RPG.WebApp.Core.Actor
{
    public class Tree: BaseActor
    {
        public Tree(Point initialPosition) : base(null, initialPosition)
        {
            Stats = new DefaultStats(Common.Settings.ActorSettings.DefaultSize, 0, 0, 0);
            _animation = new TreeAnimation();
            _collisionResolver = new IgnoringCollisionResolver(this);
        }
    }
}
