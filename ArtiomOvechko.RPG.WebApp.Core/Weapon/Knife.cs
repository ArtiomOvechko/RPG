using System;

using Chevo.RPG.WebApp.Core.Interfaces.Weapon;
using Chevo.RPG.WebApp.Core.Behavior.Projectile;
using Chevo.RPG.WebApp.Core.Actor;
using Chevo.RPG.WebApp.Core.Enum;
using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using Chevo.RPG.WebApp.Common.Settings;
using Chevo.RPG.WebApp.Core.Environment;
using Chevo.RPG.WebApp.Core.Helpers;
using Chevo.RPG.WebApp.Core.Animation;

namespace Chevo.RPG.WebApp.Core.Weapon
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
