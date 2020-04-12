using Chevo.RPG.WebApp.Core.Animation;
using Chevo.RPG.WebApp.Core.Collision;
using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using Chevo.RPG.WebApp.Core.Stats;

using System;


namespace Chevo.RPG.WebApp.Core.Actor
{
    [Serializable]
    public class Knife: BaseActor
    {
        public Knife(Point initialPosition, IActor creator) : base(null, initialPosition)
        {
            Stats = new DefaultStats(Common.Settings.ActorSettings.DefaultSize, 1, 1, Common.Settings.ActorSettings.DaggerStepLength);
            _collisionResolver = new ProjectileCollisionResolver(creator, this);
            _animation = new KnifeAnimation();
        }
    }
}
