using Chevo.RPG.Core.Interfaces.Instance;
using Chevo.RPG.Core.Actor;
using Chevo.RPG.Core.Stats;
using Chevo.RPG.Core.Behavior.Npc;
using Chevo.RPG.Core.Inventory.Weapon;
using Chevo.RPG.Common.Constants;
using System;

namespace Chevo.RPG.Core.Factories
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
                return CreateInstance(null).Actor.CurrentAnimation;
            }
        }

        public IInstance CreateInstance(Point initialPosition)
        {
            return new TestEnemyBehavior(new Sceleton(new KnifeWeaponItem(null), initialPosition));
        }
    }
}
