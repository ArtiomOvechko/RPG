using System;

using ArtiomOvechko.RPG.Desktop.Core.Animation;
using ArtiomOvechko.RPG.Desktop.Core.Collision;
using ArtiomOvechko.RPG.Desktop.Core.Environment;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Desktop.Core.Stats;


namespace ArtiomOvechko.RPG.Desktop.Core.Actor
{
    [Serializable]
    public class Bone: BaseActor
    {
        public Bone(Point initialPosition, IActor creator, IEnvironmentContainer environmentContainer) 
            : base(null, initialPosition, environmentContainer)
        {
            Stats = new DefaultStats(Common.Settings.ActorSettings.DefaultSize, 1, 3, Common.Settings.ActorSettings.DaggerStepLength);
            _collisionResolver = new ProjectileCollisionResolver(creator, this);
            _animation = new ThiefAnimation();
        }
    }
}
