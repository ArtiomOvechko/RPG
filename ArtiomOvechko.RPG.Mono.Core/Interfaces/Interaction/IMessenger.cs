using ArtiomOvechko.RPG.Mono.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Instance;
using System.ComponentModel;

namespace ArtiomOvechko.RPG.Mono.Core.Interfaces.Interaction
{
    public interface IMessenger
    {
        string Message { get; }

        void WriteMessage(IInstance instance);
    }
}
