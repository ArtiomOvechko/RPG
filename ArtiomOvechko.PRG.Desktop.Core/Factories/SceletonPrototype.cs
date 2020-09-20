using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Desktop.Core.Actor;
using ArtiomOvechko.RPG.Desktop.Core.Stats;
using ArtiomOvechko.RPG.Desktop.Core.Behavior.Npc;
using ArtiomOvechko.RPG.Desktop.Core.Inventory.Weapon;
using ArtiomOvechko.RPG.Desktop.Common.Constants;
using System;
using ArtiomOvechko.RPG.Desktop.Core.Environment;

namespace ArtiomOvechko.RPG.Desktop.Core.Factories
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
