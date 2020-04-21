using Chevo.RPG.WebApp.Core.Animation;
using Chevo.RPG.WebApp.Core.Collision;
using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using Chevo.RPG.WebApp.Core.Interfaces.Inventory;
using Chevo.RPG.WebApp.Core.Stats;

using System;
using Chevo.RPG.WebApp.Core.Environment;


namespace Chevo.RPG.WebApp.Core.Actor
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
        }
    }
}
