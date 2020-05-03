using System.ComponentModel;
using Chevo.RPG.WebApp.Core.Environment;

namespace Chevo.RPG.WebApp.ViewModel.Interfaces
{
    public interface ILevel : ILevelSurface, IPlayable, IControl, INotifyPropertyChanged
    {
        public IEnvironmentContainer Container { get; }
    }
}
