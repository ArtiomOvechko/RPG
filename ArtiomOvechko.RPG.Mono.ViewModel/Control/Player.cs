using ArtiomOvechko.RPG.Mono.Common.Commands;
using ArtiomOvechko.RPG.Mono.Core.Enum;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Mono.ViewModel.Interfaces;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Interaction;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Inventory;

using System;
using System.Windows.Input;
using System.Threading;
using ArtiomOvechko.RPG.Mono.Core.Behavior;


namespace ArtiomOvechko.RPG.Mono.ViewModel.Control
{
    [Serializable]
    public class Player: BaseBehavior, IInstance, IControl
    {
        [NonSerialized]
        private Direction _currentDirection;
        [NonSerialized]
        private ICommand _startMove;
        [NonSerialized]
        private ICommand _stopMove;
        [NonSerialized]
        private ICommand _tryInteract;
        [NonSerialized]
        private ICommand _attack;
        [NonSerialized]
        private ICommand _equipWeapon;
        [NonSerialized]
        private ICommand _unequipWeapon;
        [NonSerialized]
        private ICommand _discardWeapon;
        [NonSerialized]
        private ICommand _aim;

        public IActor Actor
        {
            get { return _currentActor; }
        }
        
        public ICommand StartMove
        {
            get
            {
                if (_startMove == null)
                {
                    _startMove = new ActionCommand((x) =>
                    {
                        _currentDirection = (Direction)x;
                        _currentActor.StartMove(_currentDirection);
                    });
                }
                return _startMove;
            }
        }

        public ICommand StopMove
        {
            get
            {
                if (_stopMove == null)
                {
                    _stopMove = new ActionCommand((x) =>
                    {
                        if (_currentDirection == (Direction)x)
                        {
                            _currentActor.StopMove();
                        }
                    });
                }
                return _stopMove;
            }
        }

        public ICommand TryInteract
        {
            get
            {
                if (_tryInteract == null)
                {
                    _tryInteract = new ActionCommand((x) =>
                    {
                        _currentActor.TryInteract();
                    });
                }
                return _tryInteract;
            }
        }

        public ICommand Attack
        {
            get
            {
                if (_attack == null)
                {
                    _attack = new ActionCommand((x) =>
                    {
                        _currentActor.Attack();
                    });
                }
                return _attack;
            }
        }

        public ICommand Aim
        {
            get
            {
                if (_aim == null)
                {
                    _aim = new ActionCommand((x) =>
                    {
                        Direction aimDirection = (Direction)x;
                        if (_currentActor.CurrentAimDirection != aimDirection)
                        {
                            _currentActor.CurrentAimDirection = aimDirection;
                        }
                    });
                }
                return _aim;
            }
        }

        public ICommand EquipWeapon
        {
            get
            {
                if (_equipWeapon == null)
                {
                    _equipWeapon = new ActionCommand((x) =>
                    {
                       _currentActor.EquipWeapon((IWeaponItem)x);
                    });
                }
                return _equipWeapon;
            }
        }

        public ICommand UnequipWeapon
        {
            get
            {
                if (_unequipWeapon == null)
                {
                    _unequipWeapon = new ActionCommand((x) =>
                    {
                        _currentActor.UnequipWeapon();
                    });
                }
                return _unequipWeapon;
            }
        }

        public ICommand DiscardWeapon
        {
            get
            {
                if (_discardWeapon == null)
                {
                    _discardWeapon = new ActionCommand((x) =>
                    {
                        _currentActor.Inventory.Discard((IItem)x);
                    });
                }
                return _discardWeapon;
            }
        }

        public string Name { get; private set; }

        public Player(IActor actor)
        {
            IsPlayer = true;
            _currentActor = actor;
        }

        public Player(IActor actor, string name)
        {
            IsPlayer = true;
            _currentActor = actor;
            Name = name;
        }

        public string GetMessage()
        {
            return null;
        }

        public override void ProcessCurrentState()
        {
            base.ProcessCurrentState();
            
            _currentActor.Move();
        }
    }
}
