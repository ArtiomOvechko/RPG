using System.ComponentModel;
using ArtiomOvechko.RPG.Desktop.Core.Environment;

namespace ArtiomOvechko.RPG.Desktop.ViewModel.Interfaces
{
    public interface ILevel : ILevelSurface, IPlayable, IControl, INotifyPropertyChanged
    {
        public IEnvironmentContainer Container { get; }
    }
}
