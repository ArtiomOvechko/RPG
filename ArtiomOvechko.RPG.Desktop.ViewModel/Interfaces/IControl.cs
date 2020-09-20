using System.Windows.Input;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Actor;

namespace ArtiomOvechko.RPG.Desktop.ViewModel.Interfaces
{
    public interface IControl: IMovable
    {
        ICommand TryInteract { get; }

        ICommand Attack { get; }

        ICommand EquipWeapon { get; }

        ICommand UnequipWeapon { get; }

        ICommand DiscardWeapon { get; }

        ICommand Aim { get; }
        
        IActor Actor { get; }
    }
}
