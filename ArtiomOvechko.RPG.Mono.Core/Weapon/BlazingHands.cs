using ArtiomOvechko.RPG.Mono.Core.Interfaces.Weapon;
using ArtiomOvechko.RPG.Mono.Core.Behavior.Projectile;
using ArtiomOvechko.RPG.Mono.Core.Enum;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Mono.Common.Settings;
using ArtiomOvechko.RPG.Mono.Core.Environment;
using ArtiomOvechko.RPG.Mono.Core.Helpers;
using ArtiomOvechko.RPG.Mono.Core.Animation;

namespace ArtiomOvechko.RPG.Mono.Core.Weapon
{
    public class BlazingHands: BaseWeapon 
    {
        private bool _canAttack = true;

        public BlazingHands()
        {
            Cooldown = WeaponSettings.KnifeCoolDown;
            Animation = new KnifeAnimation();
        }

        public override bool Attack(IActor attacker, Direction direction)
        {
            bool result = false;
            if (_canAttack)
            {
                result = true;
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

            return result;
        }
    }
}
