using Chevo.RPG.WebApp.Core.Animation;
using Chevo.RPG.WebApp.Core.Collision;
using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using Chevo.RPG.WebApp.Core.Interfaces.Inventory;
using Chevo.RPG.WebApp.Core.Stats;

using System;


namespace Chevo.RPG.WebApp.Core.Actor
{
    [Serializable]
    public class Sceleton : BaseActor
    {
        public Sceleton(IWeaponItem weapon, Point initialPostion) : base(weapon, initialPostion)
        {
            Stats = new DefaultStats(Common.Settings.ActorSettings.DefaultSize, 3, 1, Common.Settings.ActorSettings.SkeletonStepLength);
            _animation = new SceletonAnimation();
            _collisionResolver = new DefaultCollisionResolver(this);                
        }
    }
}
