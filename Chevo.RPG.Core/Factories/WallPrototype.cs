using Chevo.RPG.Core.Interfaces.Instance;
using Chevo.RPG.Core.Behavior.StaticObject;
using Chevo.RPG.Core.Actor;
using Chevo.RPG.Core.Stats;
using System;
using Chevo.RPG.Common.Constants;

namespace Chevo.RPG.Core.Factories
{
    public class WallPrototype : BaseInstancePrototype, IInstancePrototype
    {
        public string Name
        {
            get
            {
                return PrototypeNames.StoneWall;
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
            return new StaticObjectBehavior(new DungeonStoneWall(initialPosition));
        }
    }
}
