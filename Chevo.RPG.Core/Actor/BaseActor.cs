using System.ComponentModel;
using System;
using System.Linq;

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


namespace Chevo.RPG.Core.Actor
{
    /// <summary>
    /// Initial implementation
    /// </summary>
    [Serializable]
    public abstract class BaseActor : INotifyPropertyChanged, IActor
    {
        private Point _currentPosition;
        private IStats _stats;
        private Uri _currentAnimation;
        private Direction _currentAimDirection;

        protected IWeapon _currentWeapon;
        protected IActorAnimation _animation;
        protected ICollisionResolver _collisionResolver;
       

        public Direction CurrentDirection { get; set; }

        public Direction CurrentAimDirection
        {
            get
            {
                return _currentAimDirection;
            }

            set
            {
                _currentAimDirection = value;
                OnPropertyChanged("CurrentAnimation");
            }
        }

        public State CurrentState { get; private set; }

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
                switch (CurrentState)
                {
                    default:
                    case State.Idle:
                        _currentAnimation = _animation?.GetIdleAnimation(Weapon != null ? CurrentAimDirection : CurrentDirection, _currentAnimation);
                        break;
                    case State.Moving:
                        _currentAnimation = _animation?.GetMovingAnimation(Weapon != null ? CurrentAimDirection : CurrentDirection, _currentAnimation);
                        break;
                }

                return _currentAnimation;
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
                if (CurrentState != State.Moving || direction != CurrentDirection)
                {
                    CurrentDirection = direction;
                    CurrentState = State.Moving;
                    OnPropertyChanged("CurrentAnimation");
                }
            }
        }

        public int Move()
        {
            if (CurrentState == State.Moving)
            {
                return _collisionResolver.ResolveCollision(CurrentDirection);
            }

            return 0;         
        }

        public void StopMove()
        {
            if (Stats.IsAlive)
            {
                CurrentState = State.Idle;
                OnPropertyChanged("CurrentAnimation");
            }
        }

        public void Attack()
        {
            if (Stats.IsAlive)
            {
                if (_currentWeapon != null)
                {
                    _currentWeapon.Attack(this, CurrentAimDirection);
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
            if (Stats.IsAlive && interactor != null)
            {
                var collided = EnvironmentContainer.Instances.FirstOrDefault(x =>
                                Collider.InRangeOfInteraction(new CollisionModel(x.Actor), new CollisionModel(this)) &&
                                !ReferenceEquals(x.Actor, this));

                var itemNear = EnvironmentContainer.Items.FirstOrDefault(x =>
                    Collider.InRangeOfInteraction(new CollisionModel(0, x.Position.X, x.Position.Y), new CollisionModel(this)));

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
            if (Stats.IsAlive && interactor != null)
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
            CurrentDirection = Direction.Up;
            CurrentAimDirection = Direction.Right;
            CurrentState = State.Idle;          

            Inventory = new DefaultInventory();
            if (weaponItem != null)
            {
                Inventory.Add(weaponItem);
                EquipWeapon(weaponItem);
            }           
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
