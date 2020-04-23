using System.Collections.Generic;
using System.Collections.ObjectModel;
using ArtiomOvechko.RPG.WebApp.Core.Collections;
using Chevo.RPG.WebApp.Core.Interfaces.Instance;
using Chevo.RPG.WebApp.Core.Interfaces.Inventory;
using Chevo.RPG.WebApp.ViewModel.Interfaces;

namespace Chevo.RPG.WebApp.ViewModel.Interfaces
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
