using System.Collections.Generic;
using System;

using ArtiomOvechko.RPG.Common;
using ArtiomOvechko.RPG.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Core.Interfaces.Weapon;
using ArtiomOvechko.RPG.Core.Interfaces.Animation;
using ArtiomOvechko.RPG.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Core.Animation;
using ArtiomOvechko.RPG.Core.Interfaces.Collision;
using ArtiomOvechko.RPG.Common.Settings;

namespace ArtiomOvechko.RPG.Core.Actor
{
    
    public class Thief: BaseActor, IActor
    {
        public Thief(IWeapon weapon, IActorAnimation animation, ISpec spec, ICollection<IInstance> surroundingObstacles, ICollisionResolver collisionResolver) 
            : base(weapon, animation, spec, surroundingObstacles, collisionResolver)
        {
            spec.Size = ActorSettings.DefaultSize;
            spec.Damage = 1;
            spec.Lives = 3;
            spec.StepLenght = ActorSettings.ThiefStepLength;
        }

        public Thief(IWeapon weapon, ISpec spec, ICollection<IInstance> surroundingObstacles, ICollisionResolver collisionResolver) : base(weapon, spec, surroundingObstacles, collisionResolver)
        {
            spec.Size = ActorSettings.DefaultSize;
            spec.Damage = 1;
            spec.Lives = 3;
            spec.StepLenght = ActorSettings.ThiefStepLength;

            Animation = new ThiefAnimation();
        }
    }
}
