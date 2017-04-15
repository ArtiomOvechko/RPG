using ArtiomOvechko.RPG.Core.Interfaces.Interaction;
using ArtiomOvechko.RPG.Core.Interfaces.Actor;

using System.ComponentModel;
using System;


namespace ArtiomOvechko.RPG.Core.Interaction
{
    
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
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public void Clear()
        {
            Message = null;
            LastSpeakedWith = null;
        }

        public void WriteMessage(IBehavior behavior)
        {
            var message = behavior.GetMessage();
            if (message != null)
            {
                Message = message;
                LastSpeakedWith = behavior.Actor;
            }                   
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
