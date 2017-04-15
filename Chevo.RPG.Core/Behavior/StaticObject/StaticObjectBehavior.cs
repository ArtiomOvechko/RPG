using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Core.Interfaces.Instance;
using Chevo.RPG.Core.Interfaces.Interaction;

using System;

namespace Chevo.RPG.Core.Behavior.StaticObject
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
            return "";
        }

        public override void ProcessCurrentState() { }
    }
}
