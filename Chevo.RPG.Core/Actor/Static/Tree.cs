using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Core.Animation;
using Chevo.RPG.Core.Stats;
using Chevo.RPG.Core.Collision;

namespace Chevo.RPG.Core.Actor
{
    public class Tree: BaseActor, IActor
    {
        public Tree(Point initialPosition) : base(null, initialPosition)
        {
            Stats = new DefaultStats(Common.Settings.ActorSettings.DefaultSize, 0, 0, 0);
            _animation = new TreeAnimation();
            _collisionResolver = new IgnoringCollisionResolver(this);
        }
    }
}
