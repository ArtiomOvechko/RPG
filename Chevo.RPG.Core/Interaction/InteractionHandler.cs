using Chevo.RPG.Core.Interfaces.Interaction;
using System;

namespace Chevo.RPG.Core.Interaction
{
    [Serializable]
    public class InteractionHandler : IInteractionHandler
    {
        private IMessenger _messenger;

        public IMessenger Messenger
        {
            get
            {
                return _messenger;
            }
        }

        public InteractionHandler(IMessenger messenger)
        {
            _messenger = messenger;
        }
    }
}
