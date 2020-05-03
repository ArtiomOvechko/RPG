using ArtiomOvechko.RPG.Mono.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Instance;

using System;

namespace ArtiomOvechko.RPG.Mono.Core.Behavior.StaticObject
{
    [Serializable]
    public class MovableObjectBehavior : BaseBehavior, IInstance
    {
        public MovableObjectBehavior(IActor actor) : base()
        {
            _currentActor = actor;
        }

        public string GetMessage()
        {
            return string.Empty;
        }

        public override void ProcessCurrentState() { }
    }
}
