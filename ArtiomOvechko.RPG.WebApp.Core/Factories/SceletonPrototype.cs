using Chevo.RPG.WebApp.Core.Interfaces.Instance;
using Chevo.RPG.WebApp.Core.Actor;
using Chevo.RPG.WebApp.Core.Stats;
using Chevo.RPG.WebApp.Core.Behavior.Npc;
using Chevo.RPG.WebApp.Core.Inventory.Weapon;
using Chevo.RPG.WebApp.Common.Constants;
using System;

namespace Chevo.RPG.WebApp.Core.Factories
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
