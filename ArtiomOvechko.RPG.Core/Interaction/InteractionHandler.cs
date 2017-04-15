using ArtiomOvechko.RPG.Core.Interfaces.Interaction;
using System;

namespace ArtiomOvechko.RPG.Core.Interaction
{
    
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
