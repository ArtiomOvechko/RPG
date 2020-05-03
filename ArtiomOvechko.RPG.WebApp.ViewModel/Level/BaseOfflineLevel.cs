using System;
using Chevo.RPG.WebApp.Common.Commands;
using Chevo.RPG.WebApp.Core.Interfaces.Instance;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ArtiomOvechko.RPG.WebApp.Core.Collections;
using ArtiomOvechko.RPG.WebApp.ViewModel.Annotations;
using Chevo.RPG.WebApp.Core.Interfaces.Inventory;
using Chevo.RPG.WebApp.Core.Stats;
using Chevo.RPG.WebApp.Core.Enum;
using Chevo.RPG.WebApp.Core.Environment;
using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using Chevo.RPG.WebApp.ViewModel.Control;
using Chevo.RPG.WebApp.ViewModel.Interfaces;

namespace Chevo.RPG.WebApp.ViewModel.Level
{
    public abstract class BaseOfflineLevel: ILevel
    {
        private ICommand _startMove;
        private ICommand _stopMove;
        private ICommand _tryInteract;
        private ICommand _attack;
        private ICommand _equipWeapon;
        private ICommand _unequipWeapon;
        private ICommand _discardWeapon;
        private ICommand _aim;
        
        public abstract IEnvironmentContainer Container { get; protected set; }

        private enum ScreenPart
        {
            RightUp,
            RightDown,
            LeftUp,
            LeftDown
        }

        public IActor Actor => Player.Actor;
        public IControl Player { get; protected set; }
        public IViewPort ViewPort { get; protected set; }

        public ViewModelCollection<IInstance> LevelObjects { get; protected set; } = new ViewModelCollection<IInstance>();
        public ViewModelCollection<IItem> LevelItems { get; protected set; }

        public int LevelWidth { get; protected set; }
        public int LevelHeight { get; protected set; }

        public ICommand StartMove
        {
            get
            {
                if (_startMove == null)
                {
                    _startMove = new ActionCommand((x) =>
                    {
                        Player.StartMove.Execute(x);
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
                        Player.StopMove.Execute(x);
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
                        Player.TryInteract.Execute(x);
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
                        Player.Attack.Execute(x);
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
                        Point screenPoint = (Point)x;

                        ScreenPart mouseScreenPart;

                        if (screenPoint.X >= ViewPort.ScreenWidth / 2)
                        {
                            mouseScreenPart = screenPoint.Y >= ViewPort.ScreenHeight / 2 ? ScreenPart.RightDown : ScreenPart.RightUp;
                        }
                        else
                        {
                            mouseScreenPart = screenPoint.Y >= ViewPort.ScreenHeight / 2 ? ScreenPart.LeftDown : ScreenPart.LeftUp;
                        }

                        Direction aimDirection;

                        switch (mouseScreenPart)
                        {
                            default:
                            case ScreenPart.RightUp:
                                aimDirection = (ViewPort.ScreenHeight / 2 - screenPoint.Y) >= (screenPoint.X - ViewPort.ScreenWidth / 2) ? Direction.Up : Direction.Right;
                                break;
                            case ScreenPart.RightDown:
                                aimDirection = (screenPoint.Y - ViewPort.ScreenHeight / 2) >= (screenPoint.X - ViewPort.ScreenWidth / 2) ? Direction.Down : Direction.Right;
                                break;
                            case ScreenPart.LeftDown:
                                aimDirection = (screenPoint.Y - ViewPort.ScreenHeight / 2) >= (ViewPort.ScreenWidth / 2 - screenPoint.X) ? Direction.Down : Direction.Left;
                                break;
                            case ScreenPart.LeftUp:
                                aimDirection = (ViewPort.ScreenHeight / 2 - screenPoint.Y) >= (ViewPort.ScreenWidth / 2 - screenPoint.X) ? Direction.Up : Direction.Left;
                                break;
                        }

                        Player.Aim.Execute(aimDirection);
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
                        Player.EquipWeapon.Execute(x);
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
                        Player.UnequipWeapon.Execute(x);
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
                        Player.DiscardWeapon.Execute(x);
                    });
                }
                return _discardWeapon;
            }
        }

        public BaseOfflineLevel(int screenWidth, int screenHeight)
        {
        }

        protected void SubscribeOnEvents()
        {
            LevelObjects.StateChanged += (sender, args) => OnPropertyChanged(nameof(LevelObjects));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
