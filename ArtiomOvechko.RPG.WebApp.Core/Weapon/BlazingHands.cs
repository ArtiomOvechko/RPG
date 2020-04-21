using Chevo.RPG.WebApp.Core.Interfaces.Weapon;
using Chevo.RPG.WebApp.Core.Behavior.Projectile;
using Chevo.RPG.WebApp.Core.Enum;
using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using Chevo.RPG.WebApp.Common.Settings;
using Chevo.RPG.WebApp.Core.Environment;
using Chevo.RPG.WebApp.Core.Helpers;
using Chevo.RPG.WebApp.Core.Animation;

namespace Chevo.RPG.WebApp.Core.Weapon
{
    public class BlazingHands: BaseWeapon 
    {
        private bool _canAttack = true;

        public BlazingHands()
        {
            Animation = new KnifeAnimation();
        }

        public override void Attack(IActor attacker, Direction direction)
        {
            if (_canAttack)
            {
                _canAttack = false;
                ExecutionHelper.GetNew.ExecuteWithDelayAsync(() => { _canAttack = true; }, WeaponSettings.BlazingHandsCooldown);

                var actor = new Actor.Knife(new Stats.Point(attacker.Position.X, attacker.Position.Y - 30), attacker, attacker.Environment);
                var projectile = new Projectile(actor, attacker, Direction.Up, WeaponSettings.KnifeRange, WeaponSettings.BlazingHandsSound);

                var actor1 = new Actor.Knife(new Stats.Point(attacker.Position.X, attacker.Position.Y + 30), attacker, attacker.Environment);
                var projectile1 = new Projectile(actor1, attacker, Direction.Down, WeaponSettings.KnifeRange, WeaponSettings.BlazingHandsSound);

                var actor2 = new Actor.Knife(new Stats.Point(attacker.Position.X - 30, attacker.Position.Y), attacker, attacker.Environment);
                var projectile2 = new Projectile(actor2, attacker, Direction.Left, WeaponSettings.KnifeRange, WeaponSettings.BlazingHandsSound);

                var actor3 = new Actor.Knife(new Stats.Point(attacker.Position.X + 30, attacker.Position.Y), attacker, attacker.Environment);
                var projectile3 = new Projectile(actor3, attacker, Direction.Right, WeaponSettings.KnifeRange, WeaponSettings.BlazingHandsSound);

                attacker.Environment.AddInstance(projectile);
                attacker.Environment.AddInstance(projectile1);
                attacker.Environment.AddInstance(projectile2);
                attacker.Environment.AddInstance(projectile3);
            }

        }
    }
}
