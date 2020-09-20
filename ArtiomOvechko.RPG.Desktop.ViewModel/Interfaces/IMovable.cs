using System.Windows.Input;


namespace ArtiomOvechko.RPG.Desktop.ViewModel.Interfaces
{
    public interface IMovable
    {
        ICommand StartMove { get; }

        ICommand StopMove { get; }
    }
}
