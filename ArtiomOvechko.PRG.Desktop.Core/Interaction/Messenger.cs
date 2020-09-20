using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Interaction;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Actor;

using System.ComponentModel;
using System;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Desktop.Core.Stats;

namespace ArtiomOvechko.RPG.Desktop.Core.Interaction
{
    [Serializable]
    public class Messenger : IMessenger
    {
        private string _message;

        public string Message
        {
            get => _message;

            private set => _message = value;
        }
        
        public void WriteMessage(IInstance instance)
        {
            var message = instance.GetMessage();
            if (message != null)
            {
                instance.Actor.Stats.CurrentEffects.Add(new Effect(EffectType.Talking, TimeSpan.FromSeconds(10)));
                Message = message;
            }                   
        }
    }
}
