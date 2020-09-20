using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Actor;


namespace ArtiomOvechko.RPG.Desktop.Core.Interfaces.Instance
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
