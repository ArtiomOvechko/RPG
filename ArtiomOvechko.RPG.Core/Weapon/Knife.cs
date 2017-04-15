using System;

using ArtiomOvechko.RPG.Core.Interfaces.Interaction;
using ArtiomOvechko.RPG.Core.Interfaces.Weapon;
using ArtiomOvechko.RPG.Core.Behavior.Projectile;
using ArtiomOvechko.RPG.Core.Actor;
using ArtiomOvechko.RPG.Core.Animation;
using ArtiomOvechko.RPG.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Core.Collision;

namespace ArtiomOvechko.RPG.Core.Weapon
{
    
    public class Knife: IWeapon
    {
        public IBehavior Projectile(IActor creator)
        {
            var animation = new TreeAnimation();
            var actor = new Thief(null, animation, new Spec.Spec(creator.Specs.XPos, creator.Specs.YPos), creator.Surrounding, new ProjectileCollisionResolver(creator));
            return new Projectile(actor, creator);
        }
    }
}
