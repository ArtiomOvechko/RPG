using System;
using System.Collections.Concurrent;
using Chevo.RPG.WebApp.Core.Helpers;
using Chevo.RPG.WebApp.Core.Interfaces.Instance;
using Chevo.RPG.WebApp.Core.Interfaces.Inventory;
using Chevo.RPG.WebApp.Core.Extensions;

using System.Collections.ObjectModel;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArtiomOvechko.RPG.WebApp.Core.Collections;

namespace Chevo.RPG.WebApp.Core.Environment
{
    public class EnvironmentContainer : IEnvironmentContainer
    {
        private const int _bufferCapacity = 1000;
        
        private CancellationTokenSource _cts = new CancellationTokenSource();

        private IInstance[] _toAdd = new IInstance[_bufferCapacity];
        private IInstance[] _toDelete = new IInstance[_bufferCapacity];

        private int _instanceAddCounter = -1;
        private int _instanceDeleteCounter = -1;
        private int _instanceCount = 0;
        
        public ViewModelCollection<IInstance> _instances = new ViewModelCollection<IInstance>();
        public ObservableCollection<IItem> _items = new ObservableCollection<IItem>();

        public ViewModelCollection<IInstance> Instances
        {
            get { return _instances; }
            set { _instances = value; }
        }
        public ObservableCollection<IItem> Items => _items;

        public void AddInstance(IInstance instance)
        {
            _toAdd[Interlocked.Increment(ref _instanceAddCounter)] = instance;
        }

        public void RemoveInstance(IInstance instance)
        {
            _toDelete[Interlocked.Increment(ref _instanceDeleteCounter)] = instance;
        }

        public async void Run()
        {
            await ExecutionHelper.GetNew.ExecuteContinuoslyAsync(() =>
            {
                for (int i = 0; i < _instanceCount; i++)
                {
                    Instances.Items[i]?.ProcessCurrentState();
                }
                
                //Console.WriteLine("environment cycle starting...");
                //
                // ThreadStart thread1 = new ThreadStart(() =>
                // {
                //     for (int i = 0; i < _instanceCount/2; i++)
                //     {
                //         Instances.Items[i]?.ProcessCurrentState();
                //     }
                // });
                // ThreadStart thread2 = new ThreadStart(() =>
                // {
                //     for (int i = _instanceCount/2; i < _instanceCount; i++)
                //     {
                //         Instances.Items[i]?.ProcessCurrentState();
                //     }
                // });
                // // thread1.Invoke();
                // // thread2.Invoke();
                // // ThreadStart

                


                for (int i = 0; i < _instanceAddCounter + 1; i++)
                {
                    Instances.Add(_toAdd[i]);
                }

                Instances.RemoveAll(_toDelete, _instanceDeleteCounter + 1);
                
                //Console.WriteLine("Committing changes...");
                Instances.CommitStateChanges();

                _instanceCount += _instanceAddCounter - _instanceDeleteCounter;

                _toAdd = new IInstance[_bufferCapacity];
                _toDelete = new IInstance[_bufferCapacity];

                _instanceAddCounter = -1;
                _instanceDeleteCounter = -1;

                //Console.WriteLine("environment cycle ended");


            }, _cts.Token);
        }
    }
}