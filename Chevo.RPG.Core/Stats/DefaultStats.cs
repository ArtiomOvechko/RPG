using System.ComponentModel;
using System;

using Chevo.RPG.Core.Interfaces.Actor;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Chevo.RPG.Core.Stats
{
    [Serializable]
    public class DefaultStats: IStats
    {
        private int _size;     
        private int _damage;
        private int _stepLength;

        public int Size
        {
            get
            {
                return _size;
            }

            set
            {
                _size = value;
                OnPropertyChanged("Size");
            }
        }

        public int Damage
        {
            get
            {
                return _damage;
            }

            set
            {
                _damage = value;
            }
        }

        public int StepLenght
        {
            get
            {
                return _stepLength;
            }

            set
            {
                _stepLength = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                return Lives.Count > 0;
            }
        }

        public ICollection<object> Lives { get; }

        public DefaultStats(int size, int lives, int damage, int stepLength)
        {
            _size = size;          
            _damage = damage;
            _stepLength = stepLength;
            Lives = new ObservableCollection<object>();

            AddLives(lives);
        }
        
        public void AddLives(int lives)
        {
            var result = (IList)Lives;
            for (int i = 0; i < lives; i++)
            {
                result.Add(new object());
            }
        }

        public void LostLives(int lives)
        {
            var result = (ObservableCollection<object>)Lives;

            for (int i = 0; i < lives; i++)
            {
                if (result.Count > 0)
                {
                    ((ObservableCollection<object>)Lives).RemoveAt(result.Count - 1);
                }
                else
                {
                    return;
                }
            }
        }

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
