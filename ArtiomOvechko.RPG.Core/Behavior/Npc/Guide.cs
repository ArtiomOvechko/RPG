using ArtiomOvechko.RPG.Core.Helpers;
using ArtiomOvechko.RPG.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Core.Interfaces.Interaction;

using System;
using System.Linq;

namespace ArtiomOvechko.RPG.Core.Behavior.Npc
{
    
    public class Guide : BaseBehavior, IBehavior
    {
        public Guide(IActor actor): base(actor) { }

        private string _currentMessage;
        private int _interactionsCount = 6;
        private bool _interacted = false;
        private string[] _phrases = new string[] { "Oh, hello!", "New in here, aren't you?", "Use SPACE to attack, but don't even try to test in on me!", "DONT.", "EVEN.", "TRY." };

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

        protected override void ProcessCurrentState()
        {
            if (!_interacted)
            {
                var player = _currentActor.Surrounding.FirstOrDefault(x => x is IInteractor && Collider.InRangeOfInteraction(x.Actor.Specs, _currentActor.Specs));
                if (player != null)
                {
                    _currentMessage = "Heya! Wait!";
                    ((IInteractor)player).InteractionHandler.Messenger.WriteMessage(this);
                }
            }
        }
    }
}
