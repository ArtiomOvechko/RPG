using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ArtiomOvechko.RPG.WebApp.Core.Collections;
using Chevo.RPG.WebApp.Core.Interfaces.Instance;
using Chevo.RPG.WebApp.Core.Interfaces.Inventory;


namespace Chevo.RPG.WebApp.Core.Environment
{
    public interface IEnvironmentContainer
    {
        ViewModelCollection<IInstance> Instances { get; set; }
        
        ObservableCollection<IItem> Items { get; }
        
        void AddInstance(IInstance instance);

        void RemoveInstance(IInstance instance);

        void Run();
    }
}