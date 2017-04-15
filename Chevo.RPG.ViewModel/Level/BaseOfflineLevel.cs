using Chevo.RPG.Common.Commands;
using Chevo.RPG.Core.Interfaces.Instance;
using Chevo.RPG.Core.Interfaces.Interaction;
using Chevo.RPG.ViewModel.Interfaces.Level;

using System.Collections.Generic;
using System.Windows.Input;
using System;
using Chevo.RPG.Core.Interfaces.Inventory;

namespace Chevo.RPG.ViewModel.Level
{
    public class BaseOfflineLevel: ILevel
    {
        private ICommand _startMove;
        private ICommand _stopMove;
        private ICommand _tryInteract;
        private ICommand _attack;
        private ICommand _equipWeapon;
        private ICommand _unequipWeapon;
        private ICommand _discardWeapon;

        public IControl Player { get; protected set; }
        public IViewPort ViewPort { get; protected set; }

        public IEnumerable<IInstance> LevelObjects { get; protected set; }
        public IEnumerable<IItem> LevelItems { get; protected set; }

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

        public BaseOfflineLevel(int screenWidth, int screenHeight) { }
    }
}
