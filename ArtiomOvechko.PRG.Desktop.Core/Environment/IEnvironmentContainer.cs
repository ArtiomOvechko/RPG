using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ArtiomOvechko.RPG.Desktop.Core.Collections;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Inventory;


namespace ArtiomOvechko.RPG.Desktop.Core.Environment
{
    public interface IEnvironmentContainer
    {
        ViewModelCollection<IInstance> Instances { get; set; }
        
        ViewModelCollection<IItem> Items { get; }
        
        void AddInstance(IInstance instance);

        void RemoveInstance(IInstance instance);

        void Run();
    }
}