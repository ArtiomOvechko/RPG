using Chevo.RPG.WebApp.Core.Animation;
using Chevo.RPG.WebApp.Core.Collision;
using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using Chevo.RPG.WebApp.Core.Stats;

using System;
using Chevo.RPG.WebApp.Core.Environment;


namespace Chevo.RPG.WebApp.Core.Actor
{
    [Serializable]
    public class AimingMarker : BaseActor
    {
        public AimingMarker(Point initialPosition, IActor creator, IEnvironmentContainer environmentContainer) 
            : base(null, initialPosition, environmentContainer)
        {
            Stats = new DefaultStats(Common.Settings.ActorSettings.DefaultSize * 2, 1, 1, creator.Stats.StepLenght);
            _collisionResolver = new IgnoringCollisionResolver(this);
            _animation = new KnifeAnimation();
            Weapon = new Weapon.Knife();
        }
    }
}
