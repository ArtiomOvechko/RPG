using ArtiomOvechko.RPG.Mono.Core.Animation;
using ArtiomOvechko.RPG.Mono.Core.Collision;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Mono.Core.Stats;

using System;
using ArtiomOvechko.RPG.Mono.Core.Environment;


namespace ArtiomOvechko.RPG.Mono.Core.Actor
{
    [Serializable]
    public class Knife: BaseActor
    {
        public Knife(Point initialPosition, IActor creator, IEnvironmentContainer environmentContainer) 
            : base(null, initialPosition, environmentContainer)
        {
            Stats = new DefaultStats(Common.Settings.ActorSettings.DefaultSize, 1, 9, Common.Settings.ActorSettings.DaggerStepLength);
            _collisionResolver = new ProjectileCollisionResolver(creator, this);
            _animation = new KnifeAnimation();
        }
    }
}
