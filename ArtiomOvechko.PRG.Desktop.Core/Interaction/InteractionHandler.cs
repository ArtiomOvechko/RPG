using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Interaction;
using System;

namespace ArtiomOvechko.RPG.Desktop.Core.Interaction
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
