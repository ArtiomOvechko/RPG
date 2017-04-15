using Chevo.RPG.Core.Interfaces.Weapon;
using Chevo.RPG.Core.Behavior.Projectile;
using Chevo.RPG.Core.Actor;
using Chevo.RPG.Core.Enum;
using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Common.Settings;
using Chevo.RPG.Core.Environment;
using Chevo.RPG.Core.Helpers;

namespace Chevo.RPG.Core.Weapon
{
    public class BlazingHands: IWeapon 
    {
        private bool _canAttack = true;

        public void Attack(IActor attacker, Direction direction)
        {
            if (_canAttack)
            {
                _canAttack = false;
                ExecutionHelper.GetNew.ExecuteWithDelayAsync(() => { _canAttack = true; }, WeaponSettings.BlazingHandsCooldown);

                var actor = new Actor.Knife(new Stats.Point(attacker.Position.X, attacker.Position.Y - 30), attacker);
                var projectile = new Projectile(actor, attacker, Direction.Up, WeaponSettings.KnifeRange, WeaponSettings.BlazingHandsSound);

                var actor1 = new Actor.Knife(new Stats.Point(attacker.Position.X, attacker.Position.Y + 30), attacker);
                var projectile1 = new Projectile(actor1, attacker, Direction.Down, WeaponSettings.KnifeRange, WeaponSettings.BlazingHandsSound);

                var actor2 = new Actor.Knife(new Stats.Point(attacker.Position.X - 30, attacker.Position.Y), attacker);
                var projectile2 = new Projectile(actor2, attacker, Direction.Left, WeaponSettings.KnifeRange, WeaponSettings.BlazingHandsSound);

                var actor3 = new Actor.Knife(new Stats.Point(attacker.Position.X + 30, attacker.Position.Y), attacker);
                var projectile3 = new Projectile(actor3, attacker, Direction.Right, WeaponSettings.KnifeRange, WeaponSettings.BlazingHandsSound);

                EnvironmentContainer.AddInstance(projectile);
                EnvironmentContainer.AddInstance(projectile1);
                EnvironmentContainer.AddInstance(projectile2);
                EnvironmentContainer.AddInstance(projectile3);
            }

        }
    }
}
