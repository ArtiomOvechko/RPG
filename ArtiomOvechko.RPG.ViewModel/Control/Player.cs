using ArtiomOvechko.RPG.Common;
using ArtiomOvechko.RPG.Common.Helpers;
using ArtiomOvechko.RPG.Common.Commands;
using ArtiomOvechko.RPG.Core.Enum;
using ArtiomOvechko.RPG.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.ViewModel.Interfaces.Level;
using ArtiomOvechko.RPG.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Core.Interfaces.Interaction;
using ArtiomOvechko.RPG.Common.Settings;

using System;
using System.Windows.Input;
using System.Threading;
using System.Collections.Generic;


namespace ArtiomOvechko.RPG.ViewModel.Control
{   
    public class Player: IInstance, IControl, IInteractor
    {
        
        private Direction _currentDirection;
        
        private IViewPort _viewPort;
        private IActor _currentActor { get; set; }
        
        private ICommand _startMove;
        
        private ICommand _stopMove;
        
        private ICommand _tryInteract;
        
        private ICommand _attack;
        
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
                        if (cancellationTokenSource == null || cancellationTokenSource.Token.IsCancellationRequested) {
                            cancellationTokenSource = new CancellationTokenSource();
                            _currentDirection = GetDirection(x);
                            _currentActor.CurrentDirection = _currentDirection;
                            _currentActor.CurrentState = State.Moving;

                            ExecutionHelper.GetInstance.ExecuteContinuoslyAsync(() =>
                            {
                                Move(_currentDirection);
                            }, GlobalSettings.GameStepDelay, cancellationTokenSource.Token);
                        }        
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
                        if (_currentDirection == GetDirection(x))
                        {
                            _currentActor.CurrentDirection = _currentDirection;
                            _currentActor.CurrentState = State.Idle;
                            cancellationTokenSource.Cancel();
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
                        _currentActor.Attack(_currentDirection);
                    });
                }
                return _attack;
            }
        }

        public ICollection<IInstance> SurroundingObstacles { get; private set; }

        public Player(IActor actor, IViewPort viewPort, IInteractionHandler interactor)
        {
            _currentActor = actor;
            _viewPort = viewPort;
            InteractionHandler = interactor;
        }

        private void Move(Direction direction)
        {
            var offset = _currentActor.Move(direction);
            _currentActor.TryStopInteraction(InteractionHandler);
            _viewPort.Move(direction, offset);
            
        }

        private Direction GetDirection(object o)
        {
            if (o is Direction)
            {
                var x = (Direction)o;

                return x;
            } else
            {
                throw new ArgumentException();
            }
        }
    }
}
