using ArtiomOvechko.RPG.Desktop.Core.Environment;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Desktop.Core.Stats;


namespace ArtiomOvechko.RPG.Desktop.Core.Factories
{
    public interface IInstanceFactory
    {       
        IInstance CreateInstance(Point initialPosition, IEnvironmentContainer environmentContainer);
    }
}
