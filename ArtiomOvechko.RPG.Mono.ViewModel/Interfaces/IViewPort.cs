using ArtiomOvechko.RPG.Mono.Core.Stats;

using System.ComponentModel;


namespace ArtiomOvechko.RPG.Mono.ViewModel.Interfaces
{
    public interface IViewPort: INotifyPropertyChanged
    {
        Point Position { get; }

        int ScreenWidth { get; }

        int ScreenHeight { get; }
    }
}
