using Chevo.RPG.WebApp.Core.Environment;
using Chevo.RPG.WebApp.Core.Helpers;
using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using Chevo.RPG.WebApp.Core.Interfaces.Instance;
using Chevo.RPG.WebApp.Core.Interfaces.Interaction;

using System;
using System.Linq;

namespace Chevo.RPG.WebApp.Core.Behavior.Npc
{
    [Serializable]
    public class GuideBehavior : BaseBehavior, IInstance
    {
        public GuideBehavior(IActor actor): base()
        {
            _currentActor = actor;
        }

        private string _currentMessage;
        private int _interactionsCount = 6;
        private bool _interacted = false;
        private string[] _phrases = new string[] { "Oh, hello!", "New in here, aren't you?", "Use arrows to attack, but don't even try to test in on me!", "DONT.", "EVEN.", "TRY." };

        public string GetMessage()
        {
            if (_currentMessage == null)
            {
                _interacted = true;
                var index = _interactionsCount++ % _phrases.Length;
                var result = _phrases[index];
                return result;
            }
            else
            {
                var result = _currentMessage;
                _currentMessage = null;
                return result;
            }
        }

        public override void ProcessCurrentState()
        {
            base.ProcessCurrentState(); 
            
            if (!_interacted)
            {
                var player = _currentActor?.Environment.Instances.FirstOrDefault(x => x is IInteractor &&
                    Collider.InRangeOfInteraction(new CollisionModel(x.Actor), new CollisionModel(_currentActor)));
                if (player != null)
                {
                    _currentMessage = "Heya! Wait!";
                    ((IInteractor)player).InteractionHandler.Messenger.WriteMessage(this);
                }
            }
            else
            {
                _currentActor.Attack();
            }
        }
    }
}
