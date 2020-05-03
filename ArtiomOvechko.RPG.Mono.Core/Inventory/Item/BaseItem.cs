using ArtiomOvechko.RPG.Mono.Core.Interfaces.Inventory;
using ArtiomOvechko.RPG.Mono.Core.Stats;

using System;
using System.ComponentModel;

namespace ArtiomOvechko.RPG.Mono.Core.Inventory.Item
{
    public abstract class BaseItem : IItem
    {
        public Uri Animation { get; protected set; }

        public Point Position { get; private set; }

        public bool Equippable
        {
            get
            {
                return false;
            }
        }

        public bool Unequippable
        {
            get
            {
                return false;
            }
        }

        public bool Discardable
        {
            get
            {
                return true;
            }
        }

        public string Title { get; protected set; }

        public BaseItem(Point position)
        {
            Position = position;
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
