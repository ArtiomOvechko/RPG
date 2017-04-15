using Chevo.RPG.Core.Interfaces.Actor;


namespace Chevo.RPG.Core.Interfaces.Instance
{
    public interface IInstance
    {
        IActor Actor { get; }

        string GetMessage();

        void ProcessCurrentState();
    }
}
