using ArtiomOvechko.RPG.ViewModel.Interfaces.Level;
using System;

namespace ArtiomOvechko.RPG.ViewModel.Level.Representation
{
    public class DefaultLevelRepresentationalModel: ILevelRepresentationalModel
    {
        public string LevelName { get; }

        public Type LevelType { get; }

        public DefaultLevelRepresentationalModel(string  levelName, Type type)
        {
            LevelName = levelName;
            LevelType = type;
        }
    }
}
