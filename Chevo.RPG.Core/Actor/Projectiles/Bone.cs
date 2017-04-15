using Chevo.RPG.Core.Animation;
using Chevo.RPG.Core.Collision;
using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Core.Interfaces.Instance;
using Chevo.RPG.Core.Interfaces.Weapon;
using Chevo.RPG.Core.Stats;

using System;
using System.Collections.Generic;


namespace Chevo.RPG.Core.Actor
{
    [Serializable]
    public class Bone: BaseActor, IActor
    {
        public Bone(Point initialPosition, IActor creator) : base(null, initialPosition)
        {
            Stats = new DefaultStats(Common.Settings.ActorSettings.DefaultSize, 1, 3, Common.Settings.ActorSettings.DaggerStepLength);
            _collisionResolver = new ProjectileCollisionResolver(creator, this);
            _animation = new ThiefAnimation();
        }
    }
}
