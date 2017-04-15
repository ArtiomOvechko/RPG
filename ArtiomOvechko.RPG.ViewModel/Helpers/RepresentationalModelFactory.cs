using ArtiomOvechko.RPG.ViewModel.Interfaces.Level;
using ArtiomOvechko.RPG.ViewModel.Level.Representation;

using System;


namespace ArtiomOvechko.RPG.ViewModel.Helpers
{
    public static class RepresentationalModelFactory
    {
        public static ILevelRepresentationalModel GetLevelRepresentationalModel(string name, Type t)
        {
            return new DefaultLevelRepresentationalModel(name, t);
        }
    }
}
