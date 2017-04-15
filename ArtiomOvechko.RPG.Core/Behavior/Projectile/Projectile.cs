using ArtiomOvechko.RPG.Common.Helpers;
using ArtiomOvechko.RPG.Core.Enum;
using ArtiomOvechko.RPG.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Core.Interfaces.Interaction;

using System;

namespace ArtiomOvechko.RPG.Core.Behavior.Projectile
{
    
    public class Projectile: BaseBehavior, IBehavior
    {
        private Direction _movingDirection;
        private int _moveLength;
        private IActor _creator;

        public Projectile(IActor actor, IActor creator) : base(actor)
        {
            _moveLength = 600;
            _movingDirection = creator.CurrentDirection;
            _creator = creator;

            SoundPlayerHelper.GetInstance.Play();

            Execute();
        }

        public string GetMessage()
        {
            return "";
        }

        protected override void ProcessCurrentState()
        {
            var offset = Math.Abs(Actor.Move(_movingDirection));
            if (offset == 0)
            {
                _cts.Cancel();
            }
            else
            {
                _moveLength -= offset;
                
                if (_moveLength <= 0)
                {
                    _currentActor.Surrounding.Remove(this);
                    _cts.Cancel();
                }
            }           
        }
    }
}
