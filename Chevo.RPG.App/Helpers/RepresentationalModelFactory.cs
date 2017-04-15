using Chevo.RPG.App.Models;
using Chevo.RPG.App.Models.Interfaces;

using System;


namespace Chevo.RPG.ViewModel.Helpers
{
    public static class RepresentationalModelFactory
    {
        public static ILevelRepresentationalModel GetLevelRepresentationalModel(string name, Type t)
        {
            return new DefaultLevelRepresentationalModel(name, t);
        }
    }
}
