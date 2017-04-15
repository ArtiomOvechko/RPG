using ArtiomOvechko.RPG.ViewModel.Interfaces.Level;

using System.Collections.Generic;
using System.Windows.Input;

namespace ArtiomOvechko.RPG.ViewModel.Interfaces.Menu
{
    public interface ILevelChooseMenu
    {
        ICollection<ILevelRepresentationalModel> AvailableLevels { get; }

        ICommand HostLevel { get; }

        ICommand JoinLevel { get; }
    }
}
