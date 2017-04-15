using Chevo.RPG.Common.Commands;
using Chevo.RPG.Core.Enum;
using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.ViewModel.Interfaces.Level;
using Chevo.RPG.Core.Interfaces.Instance;
using Chevo.RPG.Core.Interfaces.Interaction;
using Chevo.RPG.Core.Helpers;
using Chevo.RPG.Core.Interfaces.Inventory;

using System;
using System.Windows.Input;
using System.Threading;


namespace Chevo.RPG.ViewModel.Control
{
    [Serializable]
    public class Player: IInstance, IControl, IInteractor
    {
        [NonSerialized]
        private Direction _currentDirection;
        private IActor _currentActor { get; set; }
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
        private CancellationTokenSource cancellationTokenSource;

        public IActor Actor
        {
            get { return _currentActor; }
        }

        public IInteractionHandler InteractionHandler { get; private set; }

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
                        _currentActor.TryInteract(InteractionHandler);
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

        public Player(IActor actor, IInteractionHandler interactor)
        {
            _currentActor = actor;
            InteractionHandler = interactor;
        }

        public string GetMessage()
        {
            return null;
        }

        public void ProcessCurrentState()
        {
            _currentActor.TryStopInteraction(InteractionHandler);
            _currentActor.Move();
        }
    }
}
