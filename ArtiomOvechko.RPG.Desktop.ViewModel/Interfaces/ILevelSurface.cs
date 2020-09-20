using System.Collections.Generic;
using System.Collections.ObjectModel;
using ArtiomOvechko.RPG.Desktop.Core.Collections;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Inventory;
using ArtiomOvechko.RPG.Desktop.ViewModel.Interfaces;

namespace ArtiomOvechko.RPG.Desktop.ViewModel.Interfaces
{
    public interface ILevelSurface
    {
        int LevelWidth { get; }

        int LevelHeight { get; }

        /// <summary>
        /// All level obstackles
        /// </summary>
        ViewModelCollection<IInstance> LevelObjects { get; }

        /// <summary>
        /// All level items
        /// </summary>
        ViewModelCollection<IItem> LevelItems { get; }

        /// <summary>
        /// Camera view port
        /// </summary>
        IViewPort ViewPort { get; }
    }
}
