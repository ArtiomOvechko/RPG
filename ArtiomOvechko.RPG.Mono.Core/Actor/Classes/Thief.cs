using System;

using ArtiomOvechko.RPG.Mono.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Mono.Core.Animation;
using ArtiomOvechko.RPG.Mono.Core.Stats;
using ArtiomOvechko.RPG.Mono.Core.Collision;
using ArtiomOvechko.RPG.Mono.Core.Environment;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Inventory;

namespace ArtiomOvechko.RPG.Mono.Core.Actor
{
    [Serializable]
    public class Thief: BaseActor
    {
        public Thief(IWeaponItem weapon, Point initialPosition, IEnvironmentContainer environmentContainer) 
            : base(weapon, initialPosition, environmentContainer)
        {
            Stats = new DefaultStats(Common.Settings.ActorSettings.DefaultSize, 300, 9, Common.Settings.ActorSettings.ThiefStepLength);
            _animation = new ThiefAnimation();
            _collisionResolver = new DefaultCollisionResolver(this);
            _isInteractive = true;
        }
    }
}
