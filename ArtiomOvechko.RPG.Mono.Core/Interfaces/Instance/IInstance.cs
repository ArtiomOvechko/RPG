using ArtiomOvechko.RPG.Mono.Core.Interfaces.Actor;


namespace ArtiomOvechko.RPG.Mono.Core.Interfaces.Instance
{
    public interface IInstance
    {
        bool IsPlayer { get; }
        
        IActor Actor { get; }

        string GetMessage();

        void ProcessCurrentState();

        string Name { get; }
    }
}
