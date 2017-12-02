﻿using System;

using Chevo.RPG.Core.Helpers;
using Chevo.RPG.Core.Enum;
using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Core.Environment;
using Chevo.RPG.Core.Interfaces.Instance;


namespace Chevo.RPG.Core.Behavior.Projectile
{
    /// <summary>
    /// Any thing that can be thown from a weapon
    /// </summary>
    [Serializable]
    public class Projectile: BaseBehavior, IInstance
    {
        private int _moveLength;
        private IActor _creator;

        /// <summary>
        /// Customizable instance of projectile
        /// </summary>
        /// <param name="actor">Visual representation and parameters</param>
        /// <param name="creator">From who it was created</param>
        /// <param name="concreteDirection">Direction to move</param>
        /// <param name="range">How long can it fly</param>
        /// <param name="attackSoundUriString">Sound on creation</param>
        public Projectile(IActor actor, IActor creator, Direction concreteDirection, int range, string attackSoundUriString) : base()
        {
            _moveLength = range;
            _currentActor = actor;
            _creator = creator;

            if (creator.CurrentState == State.Moving)
            {
                _currentActor.Stats.StepLenght += creator.Stats.StepLenght;
                switch (creator.CurrentDirection)
                {
                    case Direction.Up:
                        _currentActor.Position = new Stats.Point(_currentActor.Position.X, _currentActor.Position.Y - creator.Stats.Size);
                        break;
                    case Direction.Right:
                        _currentActor.Position = new Stats.Point(_currentActor.Position.X + creator.Stats.Size, _currentActor.Position.Y);
                        break;
                    case Direction.Down:
                        _currentActor.Position = new Stats.Point(_currentActor.Position.X, _currentActor.Position.Y + creator.Stats.Size);
                        break;
                    case Direction.Left:
                        _currentActor.Position = new Stats.Point(_currentActor.Position.X - creator.Stats.Size, _currentActor.Position.Y);
                        break;
                }
            }

            SoundPlayerHelper.GetInstance.Play(attackSoundUriString);

            _currentActor.StartMove(concreteDirection);
        }

        /// <summary>
        /// Message to be returned on conversation
        /// </summary>
        /// <returns>Empty string</returns>
        public string GetMessage()
        {
            return "";
        }

        /// <summary>
        /// Lifecycle step
        /// </summary>
        public override void ProcessCurrentState()
        {
            var offset = Math.Abs(Actor.Move());
            _moveLength -= offset;

            if (_moveLength <= 0)
            {
                EnvironmentContainer.RemoveInstance(this);
            }
        }
    }
}
