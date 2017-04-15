using Chevo.RPG.Core.Stats;

using System;
using System.ComponentModel;


namespace Chevo.RPG.Core.Interfaces.Inventory
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
