using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Desktop.Core.Behavior.StaticObject;
using ArtiomOvechko.RPG.Desktop.Core.Actor;
using ArtiomOvechko.RPG.Desktop.Core.Stats;
using System;
using ArtiomOvechko.RPG.Desktop.Common.Constants;
using ArtiomOvechko.RPG.Desktop.Core.Environment;

namespace ArtiomOvechko.RPG.Desktop.Core.Factories
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
