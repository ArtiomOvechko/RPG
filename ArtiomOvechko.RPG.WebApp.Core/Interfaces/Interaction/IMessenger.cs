using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using Chevo.RPG.WebApp.Core.Interfaces.Instance;
using System.ComponentModel;

namespace Chevo.RPG.WebApp.Core.Interfaces.Interaction
{
    public interface IMessenger
    {
        string Message { get; }

        void WriteMessage(IInstance instance);
    }
}
