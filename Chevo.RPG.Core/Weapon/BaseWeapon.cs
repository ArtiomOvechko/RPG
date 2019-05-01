﻿using Chevo.RPG.Core.Enum;
using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Core.Interfaces.Animation;
using Chevo.RPG.Core.Interfaces.Weapon;
using System;
using System.ComponentModel;


namespace Chevo.RPG.Core.Weapon
{
    public abstract class BaseWeapon : INotifyPropertyChanged, IWeapon
    {
        private Direction _currentDirection;

        protected IActorAnimation Animation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public int Size { get; private set; }

        public Direction CurrentDirection
        {
            get
            {
                return _currentDirection;
            }
            set
            {
                _currentDirection = value;
                OnPropertyChanged("CurrentAnimation");
            }
        }

        public Uri CurrentAnimation
        {
            get
            {
                return Animation.GetIdleAnimation(CurrentDirection, null);
            }
        }

        public void SetSize(IActor owner)
        {
            Size = owner.Stats.Size * 2;
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public abstract void Attack(IActor attacker, Direction direction);
    }
}
