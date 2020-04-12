using Chevo.RPG.WebApp.Core.Interfaces.Interaction;
using Chevo.RPG.WebApp.Core.Interfaces.Actor;

using System.ComponentModel;
using System;
using Chevo.RPG.WebApp.Core.Interfaces.Instance;

namespace Chevo.RPG.WebApp.Core.Interaction
{
    [Serializable]
    public class Messenger : IMessenger
    {
        private string _message;
        private IActor _lastSpeakedWith;

        public string Message
        {
            get
            {
                return _message;
            }

            private set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        public IActor LastSpeakedWith
        {
            get
            {
                return _lastSpeakedWith;
            }

            private set
            {
                _lastSpeakedWith = value;
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void Clear()
        {
            Message = null;
            LastSpeakedWith = null;
        }

        public void WriteMessage(IInstance instance)
        {
            var message = instance.GetMessage();
            if (message != null)
            {
                Message = message;
                LastSpeakedWith = instance.Actor;
            }                   
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
