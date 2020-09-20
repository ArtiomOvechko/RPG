using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Inventory;
using System.Collections.Generic;


namespace ArtiomOvechko.RPG.Desktop.Core.Environment
{
    /// <summary>
    /// Keeps serialized level
    /// </summary>
    public class LevelSaveMetadata
    {
        /// <summary>
        /// Displayable level title
        /// </summary>
        public string LevelName { get; }

        /// <summary>
        /// Conditions to start level
        /// </summary>
        public Dictionary<string, string> StartConditions { get; }

        /// <summary>
        /// All level obstackles
        /// </summary>
        public IEnumerable<IInstance> LevelObjects { get; }

        /// <summary>
        /// All level items
        /// </summary>
        public IEnumerable<IItem> LevelItems { get; }
    }
}
