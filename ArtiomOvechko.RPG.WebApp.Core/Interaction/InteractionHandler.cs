using Chevo.RPG.WebApp.Core.Interfaces.Interaction;
using System;

namespace Chevo.RPG.WebApp.Core.Interaction
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
