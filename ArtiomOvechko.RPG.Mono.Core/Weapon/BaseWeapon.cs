using ArtiomOvechko.RPG.Mono.Core.Enum;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Animation;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Weapon;
using System;
using System.ComponentModel;


namespace ArtiomOvechko.RPG.Mono.Core.Weapon
{
    public abstract class BaseWeapon : INotifyPropertyChanged, IWeapon
    {
        private Direction _currentDirection;
        
        public int Cooldown { get; protected set; }

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

        public abstract bool Attack(IActor attacker, Direction direction);
    }
}
