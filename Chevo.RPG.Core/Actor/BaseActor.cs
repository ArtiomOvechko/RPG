using Chevo.RPG.Core.Interfaces.Weapon;
using Chevo.RPG.Core.Interfaces.Animation;
using Chevo.RPG.Core.Enum;
using Chevo.RPG.Core.Helpers;
using Chevo.RPG.Core.Interfaces.Interaction;
using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Core.Interfaces.Collision;
using Chevo.RPG.Core.Environment;
using Chevo.RPG.Core.Stats;
using Chevo.RPG.Core.Interfaces.Inventory;
using Chevo.RPG.Core.Inventory;

using System.ComponentModel;
using System;
using System.Linq;

namespace Chevo.RPG.Core.Actor
{
    [Serializable]
    public abstract class BaseActor : INotifyPropertyChanged
    {
        private State _currentState;
        private Direction _lastDirection;
        private Direction _currentDirection;
        private Point _currentPosition;
        private IStats _stats;

        protected IWeapon _currentWeapon;
        protected IActorAnimation _animation;
        protected ICollisionResolver _collisionResolver;

        #region Properties
        public IInventory Inventory { get; private set; }

        public IWeapon Weapon
        {
            get
            {
                return _currentWeapon;
            }
            set
            {
                _currentWeapon = value;
                OnPropertyChanged("Weapon");
            }
        }

        public IStats Stats
        {
            get
            {
                return _stats;
            }

            set
            {
                _stats = value;
                OnPropertyChanged("Stats");
            }
        }

        public Uri CurrentAnimation
        {
            get
            {
                switch (_currentState)
                {
                    default:
                    case State.Idle:
                        return _animation.GetIdleAnimation(_currentDirection);
                    case State.Moving:
                        return _animation.GetMovingAnimation(_currentDirection);
                }
            }
        }

        public Point Position
        {
            get
            {
                return _currentPosition;
            }

            set
            {
                _currentPosition = value;
                OnPropertyChanged("Position");
            }
        }
        #endregion

        #region Methods
        public void StartMove(Direction direction)
        {
            if (Stats.IsAlive)
            {
                if (_currentState != State.Moving || direction != _currentDirection)
                {
                    _currentDirection = direction;
                    _currentState = State.Moving;
                    OnPropertyChanged("CurrentAnimation");
                }                
            }
        }

        public int Move()
        {
            if (_currentState == State.Moving)
            {
                return _collisionResolver.ResolveCollision(_currentDirection);
            }

            return 0;         
        }

        public void StopMove()
        {
            if (Stats.IsAlive)
            {
                _currentState = State.Idle;
                OnPropertyChanged("CurrentAnimation");
            }
        }

        public void Attack()
        {
            if (Stats.IsAlive)
            {
                if (_currentWeapon != null)
                {
                    _currentWeapon.Attack((IActor)this, _currentDirection);
                }
            }
        }

        public void HandleAttack(IStats attackerStats)
        {
            if (Stats.IsAlive)
            {
                _collisionResolver.HandleAttack(attackerStats);
            }
        }

        public void TryInteract(IInteractionHandler interactor)
        {
            if (Stats.IsAlive)
            {
                var collided = EnvironmentContainer.Instances.FirstOrDefault(x =>
                                Collider.InRangeOfInteraction(new CollisionModel(x.Actor), new CollisionModel((IActor)this)) &&
                                !ReferenceEquals(x.Actor, this));

                var itemNear = EnvironmentContainer.Items.FirstOrDefault(x =>
                    Collider.InRangeOfInteraction(new CollisionModel(0, x.Position.X, x.Position.Y), new CollisionModel((IActor)this)));

                if (itemNear == null && collided != null)
                {
                    interactor.Messenger.WriteMessage(collided);
                }
                else if (itemNear != null) {
                    Inventory.Add(itemNear);
                    EnvironmentContainer.Items.Remove(itemNear);
                }
            }
        }

        public void TryStopInteraction(IInteractionHandler interactor)
        {
            if (Stats.IsAlive)
            {
                var lastSpeakedWith = interactor.Messenger.LastSpeakedWith;
                if (lastSpeakedWith != null)
                {
                    var otherCollisionModel = new CollisionModel(lastSpeakedWith.Stats.Size, lastSpeakedWith.Position.X, lastSpeakedWith.Position.Y);
                    var thisCollisionModel = new CollisionModel(Stats.Size, Position.X, Position.Y);
                    if (!Collider.InRangeOfInteraction(otherCollisionModel, thisCollisionModel))
                    {
                        interactor.Messenger.Clear();
                    }
                }
            }
        }

        public void EquipWeapon(IWeaponItem weaponItem)
        {
            if (Stats == null || Stats.IsAlive)
            {
                UnequipWeapon();
                _currentWeapon = weaponItem.Equip();
            }            
        }

        public void UnequipWeapon()
        {
            if (Stats == null || Stats.IsAlive)
            {
                var equippedWeapon = (IWeaponItem)Inventory.Items.Where(x => x is IWeaponItem && !((IWeaponItem)x).Equippable).FirstOrDefault();
                if (equippedWeapon != null)
                {
                    equippedWeapon.Unequip();
                }
                _currentWeapon = null;
            }           
        }
        #endregion

        public BaseActor(IWeaponItem weaponItem, Point initialPosition)
        {
            Position = initialPosition;
            _currentDirection = Direction.Up;
            _currentState = State.Idle;          

            Inventory = new DefaultInventory();
            if (weaponItem != null)
            {
                Inventory.Add(weaponItem);
                EquipWeapon(weaponItem);
            }           
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
