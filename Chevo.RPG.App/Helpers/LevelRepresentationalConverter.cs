using Chevo.RPG.App.Models.Interfaces;
using Chevo.RPG.ViewModel.Interfaces.Level;

using System;


namespace Chevo.RPG.ViewModel.Helpers
{
    public class LevelRepresentationalConverter
    {
        private static  LevelRepresentationalConverter _instance;
        private static volatile object _lock = new object();

        public static LevelRepresentationalConverter GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock(_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new LevelRepresentationalConverter();
                        }
                    }
                }
                return _instance;
            }
        }

        public ILevel ConvertToLevel(ILevelRepresentationalModel model)
        {
            Type t = model.LevelType;

            return (ILevel)Activator.CreateInstance(model.LevelType);
        }

        public ILevelRepresentationalModel ConvertToModel(Type t)
        {
            return RepresentationalModelFactory.GetLevelRepresentationalModel(t.Name, t);
        }

        private LevelRepresentationalConverter() { }
    }
}
