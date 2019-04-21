using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Core.Interfaces.Instance;

using System;

namespace Chevo.RPG.Core.Behavior.StaticObject
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
