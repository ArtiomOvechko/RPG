using System;

using Chevo.RPG.WebApp.Core.Animation;
using Chevo.RPG.WebApp.Core.Collision;
using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using Chevo.RPG.WebApp.Core.Stats;


namespace Chevo.RPG.WebApp.Core.Actor
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
