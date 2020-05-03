using System.ComponentModel;
using ArtiomOvechko.RPG.Mono.Core.Environment;

namespace ArtiomOvechko.RPG.Mono.ViewModel.Interfaces
{
    public interface ILevel : ILevelSurface, IPlayable, IControl, INotifyPropertyChanged
    {
        IEnvironmentContainer Container { get; }
    }
}
