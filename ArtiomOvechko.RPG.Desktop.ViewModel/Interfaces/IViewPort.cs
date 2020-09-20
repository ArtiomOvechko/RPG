using ArtiomOvechko.RPG.Desktop.Core.Stats;

using System.ComponentModel;


namespace ArtiomOvechko.RPG.Desktop.ViewModel.Interfaces
{
    public interface IViewPort: INotifyPropertyChanged
    {
        Point Position { get; }

        int ScreenWidth { get; }

        int ScreenHeight { get; }
    }
}
