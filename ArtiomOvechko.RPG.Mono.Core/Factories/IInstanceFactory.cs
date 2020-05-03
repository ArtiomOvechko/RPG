using ArtiomOvechko.RPG.Mono.Core.Environment;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Mono.Core.Stats;


namespace ArtiomOvechko.RPG.Mono.Core.Factories
{
    public interface IInstanceFactory
    {       
        IInstance CreateInstance(Point initialPosition, IEnvironmentContainer environmentContainer);
    }
}
