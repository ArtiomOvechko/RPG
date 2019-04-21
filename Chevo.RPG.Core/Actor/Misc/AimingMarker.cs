using Chevo.RPG.Core.Animation;
using Chevo.RPG.Core.Collision;
using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Core.Stats;

using System;


namespace Chevo.RPG.Core.Actor
{
    [Serializable]
    public class AimingMarker : BaseActor
    {
        public AimingMarker(Point initialPosition, IActor creator) : base(null, initialPosition)
        {
            Stats = new DefaultStats(Common.Settings.ActorSettings.DefaultSize * 2, 1, 1, creator.Stats.StepLenght);
            _collisionResolver = new IgnoringCollisionResolver(this);
            _animation = new KnifeAnimation();
            Weapon = new Weapon.Knife();
        }
    }
}
