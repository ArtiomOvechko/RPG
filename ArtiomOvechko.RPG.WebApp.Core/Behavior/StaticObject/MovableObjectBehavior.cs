using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using Chevo.RPG.WebApp.Core.Interfaces.Instance;

using System;

namespace Chevo.RPG.WebApp.Core.Behavior.StaticObject
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
