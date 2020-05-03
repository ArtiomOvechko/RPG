using System.ComponentModel;
using System;
using System.Linq;

using ArtiomOvechko.RPG.Mono.Core.Interfaces.Weapon;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Animation;
using ArtiomOvechko.RPG.Mono.Core.Enum;
using ArtiomOvechko.RPG.Mono.Core.Helpers;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Interaction;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Collision;
using ArtiomOvechko.RPG.Mono.Core.Environment;
using ArtiomOvechko.RPG.Mono.Core.Interaction;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Mono.Core.Stats;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Inventory;
using ArtiomOvechko.RPG.Mono.Core.Inventory;
using static ArtiomOvechko.RPG.Mono.Core.Helpers.Collider;


namespace ArtiomOvechko.RPG.Mono.Core.Actor
{
    /// <summary>
    /// Initial implementation
    /// </summary>
    [Serializable]
    public abstract class BaseActor : IActor
    {
        protected bool _isInteractive = false;

        public bool IsInteractive => _isInteractive;

        public IEnvironmentContainer Environment { get; }
        
        private Point _currentPosition;
        private IStats _stats;
        private Uri _currentAnimation;
        private Direction _currentAimDirection;
        public IInteractionHandler InteractionHandler { get; }

        protected IWeapon _currentWeapon;
        protected IActorAnimation _animation;
        protected ICollisionResolver _collisionResolver;
       

        public Direction CurrentDirection { get; set; }

        public Direction CurrentAimDirection
        {
            get => _currentAimDirection;

            set
            {
                _currentAimDirection = value;
                if (_currentWeapon != null)
                {
                    _currentWeapon.CurrentDirection = value;
                }                
                //OnPropertyChanged("CurrentAnimation");
            }
        }

        public State CurrentState { get; private set; }

        #region Properties
        public IInventory Inventory { get; private set; }

        public IWeapon Weapon
        {
            get => _currentWeapon;

            set => _currentWeapon = value;
            // OnPropertyChanged("Weapon");
            // OnPropertyChanged("WeaponPosition");
        }

        public IStats Stats
        {
            get => _stats;

            set => _stats = value;
            //OnPropertyChanged("Stats");
        }

        public Uri CurrentAnimation
        {
            get
            {
                switch (CurrentState)
                {
                    case State.Moving:
                        _currentAnimation = _animation?.GetMovingAnimation(Weapon != null ? CurrentAimDirection : CurrentDirection, _currentAnimation);
                        break;
                    default:
                        _currentAnimation = _animation?.GetIdleAnimation(Weapon != null ? CurrentAimDirection : CurrentDirection, _currentAnimation);
                        break;

                }

                return _currentAnimation;
            }
        }

        public Point Position
        {
            get => _currentPosition;

            set
            {
                _currentPosition = value;
                OnPropertyChanged(nameof(Position));
            }
            // OnPropertyChanged(nameof(WeaponPosition));
            // OnPropertyChanged(nameof(HealthBarPosition));
        }
        
        public Point HealthBarPosition => 
            new Point(_currentPosition.X - ((_stats.HealthBarSize - _stats.Size) / 2), _currentPosition.Y - 10);
        
        public Point WeaponPosition => 
            new Point(_currentPosition.X + _stats.Size / 2 - Weapon?.Size / 2 ?? 0, _currentPosition.Y + _stats.Size / 2 - Weapon?.Size / 2 ?? 0);

        private bool _isDamaged;
        public bool IsDamaged => _isDamaged;

        private bool _isHealthBarShown;
        public bool IsHealthBarShown => _isHealthBarShown;
        
        private bool _isTalking;
        public bool IsTalking => _isTalking;

        private bool _isAttacking;
        public bool IsAttacking => _isAttacking;

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
                    _currentWeapon.CurrentDirection = _currentAimDirection;
                    bool attackPerformed = _currentWeapon.Attack(this, CurrentAimDirection);
                    if (attackPerformed)
                    {
                        _stats.CurrentEffects.Add(new Effect(EffectType.Attacking, TimeSpan.FromMilliseconds(this.Weapon.Cooldown)));
                    }
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

        public void ProcessCurrentState()
        {
            _isDamaged = false;
            _isHealthBarShown = false;
            _isAttacking = false;
            _isTalking = false;
            _stats.CurrentEffects = _stats.CurrentEffects.Where(e => e.EndTime >= DateTime.Now || e.IsPermanent).ToList();
            foreach (Effect effect in _stats.CurrentEffects)
            {
                if (effect.Type == EffectType.Damage)
                {
                    _isDamaged = true;
                }

                if (effect.Type == EffectType.HealthChanged)
                {
                    _isHealthBarShown = true;
                }

                if (effect.Type == EffectType.Attacking)
                {
                    _isAttacking = true;
                }

                if (effect.Type == EffectType.Talking)
                {
                    _isTalking = true;
                }
            }
        }

        public void TryInteract()
        {
            if (Stats.IsAlive)
            {
                IInstance collided = Environment.Instances.FirstOrDefault(x =>
                                x != null && InRangeOfInteraction(new CollisionModel(x.Actor), new CollisionModel(this)) &&
                                !ReferenceEquals(x.Actor, this));

                IItem itemNear = Environment.Items.FirstOrDefault(x =>
                    x != null && InRangeOfInteraction(new CollisionModel(0, x.Position.X, x.Position.Y), new CollisionModel(this)));

                if (itemNear == null)
                {
                    collided?.Actor?.InteractionHandler?.Messenger.WriteMessage(collided);
                }
                else 
                {
                    Inventory.Add(itemNear);
                    Environment.Items.RemoveAll(new []{ itemNear }, 1);
                }
            }
        }

        public void EquipWeapon(IWeaponItem weaponItem)
        {
            if (Stats == null || Stats.IsAlive)
            {
                UnequipWeapon();
                IWeapon newWeapon = weaponItem.Equip(this);
                newWeapon.CurrentDirection = CurrentDirection;
                Weapon = newWeapon;
            }
        }

        public void UnequipWeapon()
        {
            if (Stats == null || Stats.IsAlive)
            {
                IWeaponItem equippedWeapon = (IWeaponItem)Inventory.Items
                    .FirstOrDefault(x => x is IWeaponItem item && !item.Equippable);
                equippedWeapon?.Unequip();
                _currentWeapon = null;
            }           
        }
        #endregion

        protected BaseActor(IWeaponItem weaponItem, Point initialPosition, IEnvironmentContainer environmentContainer)
        {
            Environment = environmentContainer;
            
            Position = initialPosition;
            CurrentDirection = Direction.Up;
            CurrentAimDirection = Direction.Right;
            CurrentState = State.Idle;          

            Inventory = new DefaultInventory();
            if (weaponItem != null)
            {
                Inventory.Add(weaponItem);
            }           
            
            InteractionHandler = new InteractionHandler(new Messenger());
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
