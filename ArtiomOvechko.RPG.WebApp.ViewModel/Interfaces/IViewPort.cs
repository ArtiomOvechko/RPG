using Chevo.RPG.WebApp.Core.Stats;

using System.ComponentModel;


namespace Chevo.RPG.WebApp.ViewModel.Interfaces
{
    public interface IViewPort: INotifyPropertyChanged
    {
        Point Position { get; }

        int ScreenWidth { get; }

        int ScreenHeight { get; }
    }
}
