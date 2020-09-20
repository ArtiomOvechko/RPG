using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Instance;

namespace ArtiomOvechko.RPG.Desktop.Core.Collections
{
    public class ViewModelCollection<T> where T : class
    {
        private const int Capacity = 1000;

        public T[] Items { get; private set; }
        
        private int _addCounter = -1;

        public ViewModelCollection()
        {
            Items = new T[Capacity];
        }
        
        public void Add(T item)
        {
            Items[Interlocked.Increment(ref _addCounter)] = item;
            //Console.WriteLine(_addCounter);
        }
        
        public void RemoveAll(T[] itemsToRemove, int itemsToRemoveCount)
        {
            lock (this)
            {
                for (int j = 0; j < itemsToRemoveCount; j++)
                {
                    for (int i = _addCounter; i >= 0; i--)
                    {
                        if (Equals(Items[i], itemsToRemove[j]))
                        {
                            Items[i] = default;
                            break;
                        }
                    }
                }

                // if (removeLength > 0 && _addCounter > ReinitTreshold)
                // {
                int instanceCount = 0;
                T[] newItems = new T[Capacity];
                for (int i = 0; i < _addCounter + 1; i++)
                {
                    T item = Items[i];
                    if (item != null)
                    {
                        newItems[instanceCount++] = item;
                    }
                }
                Items = newItems;
                _addCounter = instanceCount - 1;
                // }
            }
        }

        public T FirstOrDefault(Func<T, bool> predicate)
        {
            return Items.FirstOrDefault(predicate);
        }
        
        // public IEnumerable<T> Where(Func<T, bool> predicate)
        // {
        //     return Items.Where(predicate);
        // }

        public void CommitStateChanges()
        {
            OnPropertyChanged();
        }

        public event PropertyChangedEventHandler StateChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            StateChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}