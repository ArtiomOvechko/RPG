using ArtiomOvechko.RPG.Core.Interfaces.Instance;

using System.Collections.Generic;
using System.Windows.Input;

namespace ArtiomOvechko.RPG.ViewModel.Interfaces.Level
{
    public interface IPlayer: IInstance, IControl
    {
        ICollection<IInstance> SurroundingObstacles { get; }
    }
}
