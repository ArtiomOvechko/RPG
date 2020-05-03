using ArtiomOvechko.RPG.Mono.Core.Stats;
using System;


namespace ArtiomOvechko.RPG.Mono.Core.Factories
{
    public interface IInstancePrototype : IInstanceFactory
    {
        string Name { get; }

        Uri Image { get; }

        Point Position { get; set; }
    }
}
