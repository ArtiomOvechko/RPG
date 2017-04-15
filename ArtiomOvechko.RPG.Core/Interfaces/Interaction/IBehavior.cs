using ArtiomOvechko.RPG.Core.Interfaces.Instance;

namespace ArtiomOvechko.RPG.Core.Interfaces.Interaction
{
    public interface IBehavior: IInstance
    {
        string GetMessage();

        void Execute();
    }
}
