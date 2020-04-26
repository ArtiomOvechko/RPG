using System.ComponentModel;
using System;

using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Chevo.RPG.WebApp.Core.Stats
{
    [Serializable]
    public class DefaultStats: IStats
    {
        private int _size;     
        private int _damage;
        private int _stepLength;
        private int _health;
        private int _totalHealth;

        public List<Effect> CurrentEffects { get; set; }

        public int Size
        {
            get
            {
                return _size;
            }

            set
            {
                _size = value;
                //OnPropertyChanged("Size");
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

        public int StepLength
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

        public bool IsAlive => _health > 0;

        public float HealthPercentage => (float)_health / _totalHealth * 100;

        public int HealthBarSize => Size * 2;

        public DefaultStats(int size, int lives, int damage, int stepLength)
        {
            _size = size;          
            _damage = damage;
            _stepLength = stepLength;
            _totalHealth = lives;
            _health = lives;
            CurrentEffects = new List<Effect>(sizeof(byte));

            AddLives(lives);
        }
        
        public void AddLives(int lives)
        {
            _health += lives;
            if (_health > _totalHealth)
            {
                _health = _totalHealth;
            }
            if (_health < 0)
            {
                _health = 0;
            }

            if (lives < 0)
            {
                CurrentEffects.Add(new Effect(EffectType.Damage, TimeSpan.FromMilliseconds(200)));
                CurrentEffects.Add(new Effect(EffectType.HealthChanged, TimeSpan.FromSeconds(2)));
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
