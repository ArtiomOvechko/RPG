using Chevo.RPG.Core.Factories;
using Chevo.RPG.ViewModel.Interfaces.Level;
using System.Collections.Generic;
using System.Windows.Input;


namespace Chevo.RPG.ViewModel.Interfaces
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
