using System;

namespace Chevo.RPG.App.Models.Interfaces
{
    public interface ILevelRepresentationalModel
    {
        string LevelName { get; }

        Type LevelType { get; }
    }
}
