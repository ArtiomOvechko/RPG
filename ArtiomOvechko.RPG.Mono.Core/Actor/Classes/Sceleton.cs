using ArtiomOvechko.RPG.Mono.Core.Animation;
using ArtiomOvechko.RPG.Mono.Core.Collision;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Inventory;
using ArtiomOvechko.RPG.Mono.Core.Stats;

using System;
using ArtiomOvechko.RPG.Mono.Core.Environment;


namespace ArtiomOvechko.RPG.Mono.Core.Actor
{
    [Serializable]
    public class Sceleton : BaseActor
    {
        public Sceleton(IWeaponItem weapon, Point initialPostion, IEnvironmentContainer environmentContainer) 
            : base(weapon, initialPostion, environmentContainer)
        {
            Stats = new DefaultStats(Common.Settings.ActorSettings.DefaultSize, 3000, 1, Common.Settings.ActorSettings.SkeletonStepLength);
            _animation = new SceletonAnimation();
            _collisionResolver = new DefaultCollisionResolver(this);
            _isInteractive = true;
        }
    }
}
