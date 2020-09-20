using ArtiomOvechko.RPG.Desktop.Core.Factories;
using ArtiomOvechko.RPG.Desktop.ViewModel.Interfaces;
using System.Collections.Generic;
using System.Windows.Input;


namespace ArtiomOvechko.RPG.Desktop.ViewModel.Interfaces
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
