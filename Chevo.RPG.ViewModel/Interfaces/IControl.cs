using System.Windows.Input;

namespace Chevo.RPG.ViewModel.Interfaces.Level
{
    public interface IControl: IMovable
    {
        ICommand TryInteract { get; }

        ICommand Attack { get; }

        ICommand EquipWeapon { get; }

        ICommand UnequipWeapon { get; }

        ICommand DiscardWeapon { get; }
    }
}
