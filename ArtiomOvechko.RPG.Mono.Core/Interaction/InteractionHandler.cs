using ArtiomOvechko.RPG.Mono.Core.Interfaces.Interaction;
using System;

namespace ArtiomOvechko.RPG.Mono.Core.Interaction
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
