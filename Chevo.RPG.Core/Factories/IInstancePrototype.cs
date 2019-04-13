using Chevo.RPG.Core.Stats;
using System;


namespace Chevo.RPG.Core.Factories
{
    public interface IInstancePrototype : IInstanceFactory
    {
        string Name { get; }

        Uri Image { get; }

        Point Position { get; set; }
    }
}
