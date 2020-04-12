using System.Windows.Input;

namespace Chevo.RPG.WebApp.ViewModel.Interfaces
{
    public interface IControl: IMovable
    {
        ICommand TryInteract { get; }

        ICommand Attack { get; }

        ICommand EquipWeapon { get; }

        ICommand UnequipWeapon { get; }

        ICommand DiscardWeapon { get; }

        ICommand Aim { get; }
    }
}
