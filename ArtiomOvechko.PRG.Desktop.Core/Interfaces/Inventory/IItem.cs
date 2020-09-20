using ArtiomOvechko.RPG.Desktop.Core.Stats;

using System;
using System.ComponentModel;


namespace ArtiomOvechko.RPG.Desktop.Core.Interfaces.Inventory
{
    public interface IItem: INotifyPropertyChanged
    {
        string Title { get; }

        Uri Animation { get; }

        bool Equippable { get; }

        bool Unequippable { get; }

        bool Discardable { get; }

        Point Position { get; }
    }
}
