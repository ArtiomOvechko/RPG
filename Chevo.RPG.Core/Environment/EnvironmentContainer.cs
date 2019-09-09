using Chevo.RPG.Core.Helpers;
using Chevo.RPG.Core.Interfaces.Instance;
using Chevo.RPG.Core.Interfaces.Inventory;
using Chevo.RPG.Core.Extensions;

using System.Collections.ObjectModel;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using Chevo.RPG.Core.Actor;
using Chevo.RPG.Core.Behavior.Projectile;
using System.Runtime.InteropServices;
using System;
using System.Diagnostics;

namespace Chevo.RPG.Core.Environment
{
    public static class EnvironmentContainer
    {
        private static CancellationTokenSource _cts = new CancellationTokenSource();

        private static List<IInstance> _toAdd = new List<IInstance>();

        private static List<IInstance> _toDelete = new List<IInstance>();

        /// experimental: try process instances only next to the player (thief as tmp)
        private static List<IInstance> _toUnhide = new List<IInstance>();

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

        public static Collection<IInstance> HiddenInstances = new Collection<IInstance>();

        [DllImport("Kernel32")]
        public static extern void AllocConsole();

        [DllImport("Kernel32")]
        public static extern void FreeConsole();

        public static async void Run()
        {
            Debug.WriteLine("Starting execution...");         

            await ExecutionHelper.GetNew.ExecuteContinuoslyAsync(() =>
            {
                TimeSpan startTime = new TimeSpan(DateTime.UtcNow.Ticks);
                Debug.WriteLine("Cycle start");

                Instances.Where(i => i.Actor.Stats.IsAlive)
                    .ForEach(i =>
                    {
                        // experimental
                        //new Thread(() => { i.ProcessCurrentState(); }).Start(); 
                        i.ProcessCurrentState();
                    });

                var observableInstances = (ObservableCollection<IInstance>)Instances;

                /// experimental: try process instances only next to the player (thief as tmp)

                foreach (IInstance instance in HiddenInstances)
                {
                    if (instance.Actor.Position.X < 3050 && instance.Actor.Position.Y < 3050)
                    {
                        _toUnhide.Add(instance);
                        AddInstance(instance);
                    }
                }

                /// experimental: try process instances only next to the player (thief as tmp)
                foreach (var removedInstance in _toUnhide)
                {
                    HiddenInstances.Remove(removedInstance);
                }

                foreach (IInstance instance in Instances)
                {
                    if (instance.Actor.Position.X >= 3050 && instance.Actor.Position.Y >= 3050)
                    {
                        if (!(instance is Projectile))
                           HiddenInstances.Add(instance);
                        RemoveInstance(instance);
                    }
                }

                ///// experimental: try process instances only next to the player (thief as tmp)
                //foreach (var instanceToHide in Instances.Where(x => !Collider.InRangeOfRender(new CollisionModel(x.Actor), new CollisionModel(Instances.First(players => players.Actor is Thief).Actor))))
                //{
                //    if (!(instanceToHide is Projectile))
                //        HiddenInstances.Add(instanceToHide);
                //    RemoveInstance(instanceToHide);
                //}

                foreach (var newInstance in _toAdd)
                {
                    observableInstances.Insert(0, newInstance);
                }

                foreach(var removedInstance in _toDelete)
                {
                    observableInstances.Remove(removedInstance);
                }

                /// experimental: try process instances only next to the player (thief as tmp)
                _toUnhide.Clear();
                _toAdd.Clear();
                _toDelete.Clear();

                double total = DateTime.UtcNow.Ticks - startTime.Ticks;
                Debug.WriteLine("Cycle end. Execution time: {0} ticks.", total);
            }, _cts.Token);
        }
    }
}