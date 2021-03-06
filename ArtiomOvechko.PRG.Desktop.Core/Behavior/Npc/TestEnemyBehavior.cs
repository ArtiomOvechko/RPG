﻿using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Inventory;
using System;
using System.Linq;

namespace ArtiomOvechko.RPG.Desktop.Core.Behavior.Npc
{
    [Serializable]
    public class TestEnemyBehavior : BaseBehavior, IInstance
    {
        public int _distancePassed = 0;

        public TestEnemyBehavior(IActor actor) : base()
        {
            _currentActor = actor;
            _currentActor.StartMove(Enum.Direction.Right);
            _currentActor.UnequipWeapon();
        }

        public string GetMessage()
        {
            return string.Empty;
        }

        public override void ProcessCurrentState()
        {
            _distancePassed += _currentActor.Move();

            //reconsider quipping ANY item because it is exception-prone case
            if (_currentActor.Weapon == null && _currentActor.Inventory.Items.FirstOrDefault() != null)
            {
                _currentActor.EquipWeapon((IWeaponItem)_currentActor.Inventory.Items.FirstOrDefault());
            }

            if (_distancePassed > 100)
            {
                _distancePassed = 0;
                _currentActor.StopMove();
                switch (_currentActor.CurrentDirection)
                {
                    //default:
                    case Enum.Direction.Right:
                        _currentActor.StartMove(Enum.Direction.Down);
                        break;
                    case Enum.Direction.Left:
                        _currentActor.StartMove(Enum.Direction.Up);
                        break;
                    case Enum.Direction.Up:
                        _currentActor.StartMove(Enum.Direction.Right);
                        break;
                    case Enum.Direction.Down:
                        _currentActor.StartMove(Enum.Direction.Left);
                        break;
                }              
            }

            _currentActor.Attack();

            base.ProcessCurrentState();         
        }
    }
}
