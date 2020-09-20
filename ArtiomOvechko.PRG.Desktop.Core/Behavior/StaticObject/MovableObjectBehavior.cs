using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Instance;

using System;

namespace ArtiomOvechko.RPG.Desktop.Core.Behavior.StaticObject
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
