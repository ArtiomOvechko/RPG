using System.Windows.Input;

namespace ArtiomOvechko.RPG.ViewModel.Interfaces.Level
{
    public interface IControl
    {
        ICommand StartMove { get; }

        ICommand StopMove { get; }

        ICommand TryInteract { get; }

        ICommand Attack { get; }
    }
}
