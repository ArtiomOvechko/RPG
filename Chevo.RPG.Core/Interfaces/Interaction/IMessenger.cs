using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Core.Interfaces.Instance;
using System.ComponentModel;

namespace Chevo.RPG.Core.Interfaces.Interaction
{
    public interface IMessenger: INotifyPropertyChanged
    {
        string Message { get; }

        void WriteMessage(IInstance instance);

        void Clear();

        IActor LastSpeakedWith { get; }
    }
}
