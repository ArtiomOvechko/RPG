using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Interaction;

using System;

namespace ArtiomOvechko.RPG.Desktop.Core.Behavior.StaticObject
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
