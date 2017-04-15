using ArtiomOvechko.RPG.Core.Enum;
using System.ComponentModel;

namespace ArtiomOvechko.RPG.ViewModel.Interfaces.Level
{
    public interface IViewPort: INotifyPropertyChanged
    {
        int Width { get; }

        int Height { get; }

        int XPos { get; }

        int YPos { get; }

        void Move(Direction direction, int offset);
    }
}
