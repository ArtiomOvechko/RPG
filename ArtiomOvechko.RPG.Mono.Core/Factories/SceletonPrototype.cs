using ArtiomOvechko.RPG.Mono.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Mono.Core.Actor;
using ArtiomOvechko.RPG.Mono.Core.Stats;
using ArtiomOvechko.RPG.Mono.Core.Behavior.Npc;
using ArtiomOvechko.RPG.Mono.Core.Inventory.Weapon;
using ArtiomOvechko.RPG.Mono.Common.Constants;
using System;
using ArtiomOvechko.RPG.Mono.Core.Environment;

namespace ArtiomOvechko.RPG.Mono.Core.Factories
{
    public class SceletonPrototype : BaseInstancePrototype, IInstancePrototype
    {
        public string Name
        {
            get
            {
                return PrototypeNames.SceletonEnemy;
            }
        }
        public Uri Image
        {
            get
            {
                return CreateInstance(null, null).Actor.CurrentAnimation;
            }
        }

        public IInstance CreateInstance(Point initialPosition, IEnvironmentContainer environmentContainer)
        {
            return new TestEnemyBehavior(new Sceleton(new KnifeWeaponItem(null), initialPosition, environmentContainer));
        }
    }
}
