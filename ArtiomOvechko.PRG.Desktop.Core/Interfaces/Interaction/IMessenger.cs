using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Instance;
using System.ComponentModel;

namespace ArtiomOvechko.RPG.Desktop.Core.Interfaces.Interaction
{
    public interface IMessenger
    {
        string Message { get; }

        void WriteMessage(IInstance instance);
    }
}
