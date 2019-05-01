using System;

using Chevo.RPG.Core.Interfaces.Weapon;
using Chevo.RPG.Core.Behavior.Projectile;
using Chevo.RPG.Core.Actor;
using Chevo.RPG.Core.Enum;
using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Common.Settings;
using Chevo.RPG.Core.Environment;
using Chevo.RPG.Core.Helpers;
using Chevo.RPG.Core.Animation;

namespace Chevo.RPG.Core.Weapon
{
    [Serializable]
    public class Knife: BaseWeapon
    {
        private bool _canAttack = true;

        public Knife()
        {
            Animation = new KnifeAnimation();
        }

        public override void Attack(IActor attacker, Direction direction)
        {
            if (_canAttack)
            {
                _canAttack = false;
                ExecutionHelper.GetNew.ExecuteWithDelayAsync(() => { _canAttack = true; }, WeaponSettings.KnifeCoolDown);

                var actor = new Actor.Knife(new Stats.Point(attacker.Position.X, attacker.Position.Y), attacker);
                var projectile = new Projectile(actor, attacker, direction, WeaponSettings.KnifeRange, WeaponSettings.KnifeSound);
                
                EnvironmentContainer.AddInstance(projectile);
            }
            
        }
    }
}
