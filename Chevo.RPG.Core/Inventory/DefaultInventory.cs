using Chevo.RPG.Core.Interfaces.Inventory;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace Chevo.RPG.Core.Inventory
{
    public class DefaultInventory : IInventory
    {
        private ObservableCollection<IItem> _items = new ObservableCollection<IItem>(); 

        public ObservableCollection<IItem> Items
        {
            get
            {
                return _items;
            }
        }

        public void Add(IItem item)
        {
            if (!_items.Contains(item))
            {
                _items.Add(item);
                OnPropertyChanged("Items");
            }
        }

        public void Discard(IItem item)
        {
            if (_items.Contains(item))
            {
                _items.Remove(item);
                OnPropertyChanged("Items");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
