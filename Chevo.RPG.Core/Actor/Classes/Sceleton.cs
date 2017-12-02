using Chevo.RPG.Core.Animation;
using Chevo.RPG.Core.Collision;
using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Core.Interfaces.Inventory;
using Chevo.RPG.Core.Stats;

using System;


namespace Chevo.RPG.Core.Actor
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
