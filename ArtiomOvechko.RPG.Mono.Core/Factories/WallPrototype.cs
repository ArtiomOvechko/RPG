using ArtiomOvechko.RPG.Mono.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Mono.Core.Behavior.StaticObject;
using ArtiomOvechko.RPG.Mono.Core.Actor;
using ArtiomOvechko.RPG.Mono.Core.Stats;
using System;
using ArtiomOvechko.RPG.Mono.Common.Constants;
using ArtiomOvechko.RPG.Mono.Core.Environment;

namespace ArtiomOvechko.RPG.Mono.Core.Factories
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
