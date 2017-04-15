using Chevo.RPG.App.Models.Interfaces;
using System;

namespace Chevo.RPG.App.Models
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
