using Chevo.RPG.WebApp.Core.Stats;
using System;


namespace Chevo.RPG.WebApp.Core.Factories
{
    public interface IInstancePrototype : IInstanceFactory
    {
        string Name { get; }

        Uri Image { get; }

        Point Position { get; set; }
    }
}
