using Chevo.RPG.WebApp.Core.Interfaces.Instance;
using Chevo.RPG.WebApp.Core.Behavior.StaticObject;
using Chevo.RPG.WebApp.Core.Actor;
using Chevo.RPG.WebApp.Core.Stats;
using System;
using Chevo.RPG.WebApp.Common.Constants;
using Chevo.RPG.WebApp.Core.Environment;

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
                return CreateInstance(null, null).Actor.CurrentAnimation;
            }
        }

        public IInstance CreateInstance(Point initialPosition, IEnvironmentContainer environmentContainer)
        {
            return new StaticObjectBehavior(new DungeonStoneWall(initialPosition, environmentContainer));
        }
    }
}
