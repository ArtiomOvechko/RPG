using Chevo.RPG.WebApp.Core.Interfaces.Interaction;
using Chevo.RPG.WebApp.Core.Interfaces.Actor;

using System.ComponentModel;
using System;
using Chevo.RPG.WebApp.Core.Interfaces.Instance;
using Chevo.RPG.WebApp.Core.Stats;

namespace Chevo.RPG.WebApp.Core.Interaction
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
