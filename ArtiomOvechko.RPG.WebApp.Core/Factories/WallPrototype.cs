using Chevo.RPG.WebApp.Core.Interfaces.Instance;
using Chevo.RPG.WebApp.Core.Behavior.StaticObject;
using Chevo.RPG.WebApp.Core.Actor;
using Chevo.RPG.WebApp.Core.Stats;
using System;
using Chevo.RPG.WebApp.Common.Constants;

namespace Chevo.RPG.WebApp.Core.Factories
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
