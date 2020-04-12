using Chevo.RPG.WebApp.Core.Factories;
using Chevo.RPG.WebApp.ViewModel.Interfaces;
using System.Collections.Generic;
using System.Windows.Input;


namespace Chevo.RPG.WebApp.ViewModel.Interfaces
{
    public interface IEditorLevel : ILevelSurface, IPlayable, IMovable
    {
        IEnumerable<IInstancePrototype> PickableObjects { get; }

        IEnumerable<IInstancePrototype> ActivePrototypes { get; }

        ICommand MovePickedObject { get; }

        ICommand PickObject { get; }

        ICommand PutObject { get; }

        ICommand DiscardObject { get; }
    }
}
