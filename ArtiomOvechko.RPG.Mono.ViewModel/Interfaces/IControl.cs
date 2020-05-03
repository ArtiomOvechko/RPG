using System.Windows.Input;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Actor;

namespace ArtiomOvechko.RPG.Mono.ViewModel.Interfaces
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
