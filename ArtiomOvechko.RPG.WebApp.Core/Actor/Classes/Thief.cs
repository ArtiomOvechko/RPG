using System;

using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using Chevo.RPG.WebApp.Core.Animation;
using Chevo.RPG.WebApp.Core.Stats;
using Chevo.RPG.WebApp.Core.Collision;
using Chevo.RPG.WebApp.Core.Environment;
using Chevo.RPG.WebApp.Core.Interfaces.Inventory;

namespace Chevo.RPG.WebApp.Core.Actor
{
    [Serializable]
    public class Thief: BaseActor
    {
        public Thief(IWeaponItem weapon, Point initialPosition, IEnvironmentContainer environmentContainer) 
            : base(weapon, initialPosition, environmentContainer)
        {
            Stats = new DefaultStats(Common.Settings.ActorSettings.DefaultSize, 3, 3, Common.Settings.ActorSettings.ThiefStepLength);
            _animation = new ThiefAnimation();
            _collisionResolver = new DefaultCollisionResolver(this);
        }
    }
}
