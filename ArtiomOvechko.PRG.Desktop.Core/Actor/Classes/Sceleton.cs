using ArtiomOvechko.RPG.Desktop.Core.Animation;
using ArtiomOvechko.RPG.Desktop.Core.Collision;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Inventory;
using ArtiomOvechko.RPG.Desktop.Core.Stats;

using System;
using ArtiomOvechko.RPG.Desktop.Core.Environment;


namespace ArtiomOvechko.RPG.Desktop.Core.Actor
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
