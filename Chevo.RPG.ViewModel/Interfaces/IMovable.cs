using System.Windows.Input;


namespace Chevo.RPG.ViewModel.Interfaces
{
    public interface IMovable
    {
        ICommand StartMove { get; }

        ICommand StopMove { get; }
    }
}
