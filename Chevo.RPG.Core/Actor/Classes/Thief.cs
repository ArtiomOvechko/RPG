using System;

using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Core.Animation;
using Chevo.RPG.Core.Stats;
using Chevo.RPG.Core.Collision;
using Chevo.RPG.Core.Interfaces.Inventory;

namespace Chevo.RPG.Core.Actor
{
    [Serializable]
    public class Thief: BaseActor, IActor
    {
        public Thief(IWeaponItem weapon, Point initialPosition) : base(weapon, initialPosition)
        {
            Stats = new DefaultStats(Common.Settings.ActorSettings.DefaultSize, 3, 3, Common.Settings.ActorSettings.ThiefStepLength);
            _animation = new ThiefAnimation();
            _collisionResolver = new DefaultCollisionResolver(this);
        }
    }
}
