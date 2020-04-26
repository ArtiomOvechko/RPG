using Chevo.RPG.WebApp.Core.Interfaces.Actor;


namespace Chevo.RPG.WebApp.Core.Interfaces.Instance
{
    public interface IInstance
    {
        public bool IsPlayer { get; }
        
        IActor Actor { get; }

        string GetMessage();

        void ProcessCurrentState();

        string Name { get; }
    }
}
