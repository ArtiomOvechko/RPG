using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using Chevo.RPG.WebApp.Core.Interfaces.Instance;
using Chevo.RPG.WebApp.Core.Interfaces.Interaction;

using System;

namespace Chevo.RPG.WebApp.Core.Behavior.StaticObject
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
