using ArtiomOvechko.RPG.Mono.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Interaction;

using System;

namespace ArtiomOvechko.RPG.Mono.Core.Behavior.StaticObject
{
    [Serializable]
    public class StaticObjectBehavior : BaseBehavior, IInstance
    {
        public StaticObjectBehavior(IActor actor) : base()
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
