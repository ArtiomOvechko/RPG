using Chevo.RPG.Core.Interfaces.Instance;
using Chevo.RPG.Core.Stats;


namespace Chevo.RPG.Core.Factories
{
    public interface IInstanceFactory
    {       
        IInstance CreateInstance(Point initialPosition);
    }
}
