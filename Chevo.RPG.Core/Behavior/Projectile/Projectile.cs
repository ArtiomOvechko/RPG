using System;

using Chevo.RPG.Core.Helpers;
using Chevo.RPG.Core.Enum;
using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Core.Environment;
using Chevo.RPG.Core.Interfaces.Instance;

namespace Chevo.RPG.Core.Behavior.Projectile
{
    [Serializable]
    public class Projectile: BaseBehavior, IInstance
    {
        protected int _moveLength;
        protected IActor _creator;

        public Projectile(IActor actor, IActor creator, Direction concreteDirection, int range, string attackSoundUriString) : base()
        {
            _moveLength = range;
            _currentActor = actor;
            _creator = creator;


            // Implement fancy appearing of projectile depending on creator direction
            //if (attacker.CurrentState == State.Moving)
            //{
            //    switch (projectile.Actor.)
            //    projectile.Actor.Stats.StepLenght += attacker.Stats.StepLenght;
            //}

            SoundPlayerHelper.GetInstance.Play(attackSoundUriString);

            _currentActor.StartMove(concreteDirection);
        }

        public string GetMessage()
        {
            return "";
        }

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
