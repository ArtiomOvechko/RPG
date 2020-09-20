using ArtiomOvechko.RPG.Desktop.Core.Stats;
using System;


namespace ArtiomOvechko.RPG.Desktop.Core.Factories
{
    public interface IInstancePrototype : IInstanceFactory
    {
        string Name { get; }

        Uri Image { get; }

        Point Position { get; set; }
    }
}
