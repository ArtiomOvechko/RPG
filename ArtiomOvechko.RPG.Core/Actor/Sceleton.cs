using ArtiomOvechko.RPG.Common.Settings;
using ArtiomOvechko.RPG.Core.Animation;
using ArtiomOvechko.RPG.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Core.Interfaces.Animation;
using ArtiomOvechko.RPG.Core.Interfaces.Collision;
using ArtiomOvechko.RPG.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Core.Interfaces.Weapon;

using System.Collections.Generic;


namespace ArtiomOvechko.RPG.Core.Actor
{
    public class Sceleton : BaseActor, IActor
    {
        private void Init(ISpec spec)
        {
            spec.Size = ActorSettings.DefaultSize;
            spec.Damage = 1;
            spec.Lives = 3;
            spec.StepLenght = ActorSettings.SkeletonStepLength;
        }

        public Sceleton(IWeapon weapon, IActorAnimation animation, ISpec spec, ICollection<IInstance> surroundingObstacles, ICollisionResolver collisionResolver)
            : base(weapon, animation, spec, surroundingObstacles, collisionResolver)
        {
            Init(spec);
        }

        public Sceleton(IWeapon weapon, ISpec spec, ICollection<IInstance> surroundingObstacles, ICollisionResolver collisionResolver) : base(weapon, spec, surroundingObstacles, collisionResolver)
        {
            Init(spec);

            Animation = new SceletonAnimation();
        }
    }
}
