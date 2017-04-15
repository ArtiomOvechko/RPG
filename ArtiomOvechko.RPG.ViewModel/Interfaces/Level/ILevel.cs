using ArtiomOvechko.RPG.Core.Interfaces.Instance;

using System.Collections.Generic;


namespace ArtiomOvechko.RPG.ViewModel.Interfaces.Level
{
    public interface ILevel: IPlayable, IControl
    {
        /// <summary>
        /// All level instances
        /// </summary>
        ICollection<IInstance> LevelObjects { get; }
    }
}
