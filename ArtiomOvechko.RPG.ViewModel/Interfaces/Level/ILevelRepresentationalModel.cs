using System;

namespace ArtiomOvechko.RPG.ViewModel.Interfaces.Level
{
    public interface ILevelRepresentationalModel
    {
        string LevelName { get; }

        Type LevelType { get; }
    }
}
