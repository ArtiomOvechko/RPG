using ArtiomOvechko.RPG.Core.Interfaces.Actor;

using System.ComponentModel;

namespace ArtiomOvechko.RPG.Core.Interfaces.Interaction
{
    public interface IMessenger: INotifyPropertyChanged
    {
        string Message { get; }

        void WriteMessage(IBehavior behavior);

        void Clear();

        IActor LastSpeakedWith { get; }
    }
}
