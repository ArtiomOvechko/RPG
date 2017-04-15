﻿using Chevo.RPG.Core.Helpers;
using Chevo.RPG.Core.Interfaces.Instance;
using Chevo.RPG.Core.Interfaces.Inventory;
using Chevo.RPG.Core.Extensions;

using System.Collections.ObjectModel;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace Chevo.RPG.Core.Environment
{
    public static class EnvironmentContainer
    {
        private static CancellationTokenSource _cts = new CancellationTokenSource();

        private static List<IInstance> _toAdd = new List<IInstance>();

        private static List<IInstance> _toDelete = new List<IInstance>();

        public static IEnumerable<IInstance> Instances = new ObservableCollection<IInstance>();

        public static void AddInstance(IInstance instance)
        {
            _toAdd.Add(instance);
        }

        public static void RemoveInstance(IInstance instance)
        {
            _toDelete.Add(instance);
        }

        public static ObservableCollection<IItem> Items = new ObservableCollection<IItem>();

        public static async void Run()
        {
            await ExecutionHelper.GetNew.ExecuteContinuoslyAsync(() =>
            {

                Instances.Where(i => i.Actor.Stats.IsAlive)
                    .ForEach(i => {
                        i.ProcessCurrentState();
                   });

                var observableInstances = (ObservableCollection<IInstance>)Instances;

                foreach(var newInstance in _toAdd)
                {
                    observableInstances.Insert(0, newInstance);
                }

                foreach(var removedInstance in _toDelete)
                {
                    observableInstances.Remove(removedInstance);
                }

                _toAdd.Clear();
                _toDelete.Clear();
            }, _cts.Token);
        }
    }
}