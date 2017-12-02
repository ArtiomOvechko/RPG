using System;

using Chevo.RPG.Core.Animation;
using Chevo.RPG.Core.Collision;
using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Core.Stats;


namespace Chevo.RPG.Core.Actor
{
    [Serializable]
    public class Bone: BaseActor
    {
        public Bone(Point initialPosition, IActor creator) : base(null, initialPosition)
        {
            Stats = new DefaultStats(Common.Settings.ActorSettings.DefaultSize, 1, 3, Common.Settings.ActorSettings.DaggerStepLength);
            _collisionResolver = new ProjectileCollisionResolver(creator, this);
            _animation = new ThiefAnimation();
        }
    }
}
