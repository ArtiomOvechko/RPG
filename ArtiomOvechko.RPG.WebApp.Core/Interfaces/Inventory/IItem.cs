using Chevo.RPG.WebApp.Core.Stats;

using System;
using System.ComponentModel;


namespace Chevo.RPG.WebApp.Core.Interfaces.Inventory
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
