using Chevo.RPG.Core.Stats;

using System.ComponentModel;


namespace Chevo.RPG.ViewModel.Interfaces.Level
{
    public interface IViewPort: INotifyPropertyChanged
    {
        Point Position { get; }

        int ScreenWidth { get; }

        int ScreenHeight { get; }
    }
}
