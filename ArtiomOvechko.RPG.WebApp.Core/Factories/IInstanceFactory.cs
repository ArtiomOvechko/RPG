using Chevo.RPG.WebApp.Core.Interfaces.Instance;
using Chevo.RPG.WebApp.Core.Stats;


namespace Chevo.RPG.WebApp.Core.Factories
{
    public interface IInstanceFactory
    {       
        IInstance CreateInstance(Point initialPosition);
    }
}
