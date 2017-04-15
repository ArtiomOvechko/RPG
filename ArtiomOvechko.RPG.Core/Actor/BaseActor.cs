using ArtiomOvechko.RPG.Core.Interfaces.Weapon;
using ArtiomOvechko.RPG.Core.Interfaces.Animation;
using ArtiomOvechko.RPG.Core.Enum;
using ArtiomOvechko.RPG.Core.Helpers;
using ArtiomOvechko.RPG.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Core.Interfaces.Interaction;
using ArtiomOvechko.RPG.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Core.Interfaces.Collision;

using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ArtiomOvechko.RPG.Core.Actor
{
    public abstract class BaseActor: INotifyPropertyChanged
    {
        private State _currentState;

        private Direction _lastDirection;
        private Direction _currentDirection;

        private ICollisionResolver _collisionResolver;
        private ISpec _specs;

        protected IActorAnimation _animation;
        protected IWeapon _currentWeapon;

        public IActorAnimation Animation
        {
            get
            {
                return _animation;
            }

            set
            {
                _animation = value;
                OnPropertyChanged("CurrentAnimation");
            }
        }

        public IWeapon Weapon { get { return _currentWeapon; } }

        public State CurrentState
        {
            get
            {
                return _currentState;
            }

            set
            {
                _currentState = value;
                OnPropertyChanged("CurrentAnimation");
            }
        }

        public ICollection<IInstance> Surrounding { get; private set; }

        public Direction CurrentDirection
        {
            get
            {
                return _currentDirection;
            }
            
            set
            {
                switch (_currentDirection)
                {
                    case Direction.Left:
                    case Direction.Right:
                        _lastDirection = _currentDirection;
                        break;
                }
                
                _currentDirection = value;
                OnPropertyChanged("CurrentAnimation");

            }
        }

        public ISpec Specs {
            get
            {
                return _specs;
            }

            set
            {
                _specs = value;
                OnPropertyChanged("Specs");
            }
        }

        public Uri CurrentAnimation
        {
            get
            {
                var direction = (_currentDirection == Direction.Right || _currentDirection == Direction.Left) ? _currentDirection : _lastDirection;
                switch (_currentState)
                {
                    default:
                    case State.Idle:
                        return _animation.GetIdleAnimation(direction);
                        break;
                    case State.Moving:
                        return _animation.GetMovingAnimation(direction);
                        break;
                }
            }
        }

        public int Move(Direction direction)
        {
            return _collisionResolver.ResolveCollision((IActor)this, direction);
        }

        public void Attack(Direction direction)
        {
            Surrounding
                .Add(_currentWeapon.Projectile((IActor)this));
        }

        public void TryInteract(IInteractionHandler interactor)
        {
            var collided = Surrounding.FirstOrDefault(x => Collider.InRangeOfInteraction(x.Actor.Specs, Specs) && !ReferenceEquals(x.Actor, this));

            var interactedNPC = collided as IBehavior;
            if (interactedNPC != null)
            {
                interactor.Messenger.WriteMessage(interactedNPC);
            }
        }

        public void TryStopInteraction(IInteractionHandler interactor)
        {
            var lastSpeakedWith = interactor.Messenger.LastSpeakedWith;
            if (lastSpeakedWith != null)
            {
                if (!Collider.InRangeOfInteraction(lastSpeakedWith.Specs, Specs))
                {
                    interactor.Messenger.Clear();
                }
            }
        }

        public BaseActor(IWeapon weapon, IActorAnimation animation, ISpec specs, ICollection<IInstance> surroundingObstacles, ICollisionResolver collisionResolver)
        {
            _currentWeapon = weapon;
            _collisionResolver = collisionResolver;
            _animation = animation;
            CurrentDirection = Direction.Up;
            CurrentState = State.Idle;
            Surrounding = surroundingObstacles;
            Specs = specs;
        }

        public BaseActor(IWeapon weapon, ISpec specs, ICollection<IInstance> surroundingObstacles, ICollisionResolver collisionResolver)
        {
            _collisionResolver = collisionResolver;
            _currentWeapon = weapon;
            Specs = specs;
            CurrentDirection = Direction.Up;
            CurrentState = State.Idle;
            Surrounding = surroundingObstacles;
        }

        public void Hit(ISpec attackerStats)
        {
            Specs.Lives -= attackerStats.Damage;
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
