using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ArtiomOvechko.RPG.WebApp.Core.Collections;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Inventory;


namespace ArtiomOvechko.RPG.Mono.Core.Environment
{
    public interface IEnvironmentContainer
    {
        ViewModelCollection<IInstance> Instances { get; set; }
        
        ViewModelCollection<IItem> Items { get; }
        
        void AddInstance(IInstance instance);

        void RemoveInstance(IInstance instance);

        void Run();

        void ProcessAll();
    }
}