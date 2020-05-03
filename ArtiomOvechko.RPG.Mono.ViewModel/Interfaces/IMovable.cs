using System.Windows.Input;


namespace ArtiomOvechko.RPG.Mono.ViewModel.Interfaces
{
    public interface IMovable
    {
        ICommand StartMove { get; }

        ICommand StopMove { get; }
    }
}
