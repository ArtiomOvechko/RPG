using ArtiomOvechko.RPG.Desktop.Core.Animation;
using ArtiomOvechko.RPG.Desktop.Core.Collision;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Desktop.Core.Stats;

using System;
using ArtiomOvechko.RPG.Desktop.Core.Environment;


namespace ArtiomOvechko.RPG.Desktop.Core.Actor
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
