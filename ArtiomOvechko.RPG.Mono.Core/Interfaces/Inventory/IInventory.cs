using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ArtiomOvechko.RPG.Mono.Core.Interfaces.Inventory
{
    public interface IInventory: INotifyPropertyChanged
    {
        ObservableCollection<IItem> Items { get; }

        void Add(IItem item);

        void Discard(IItem item);
    }
}