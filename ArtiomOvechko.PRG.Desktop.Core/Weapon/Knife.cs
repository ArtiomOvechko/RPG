using System;

using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Weapon;
using ArtiomOvechko.RPG.Desktop.Core.Behavior.Projectile;
using ArtiomOvechko.RPG.Desktop.Core.Actor;
using ArtiomOvechko.RPG.Desktop.Core.Enum;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Desktop.Common.Settings;
using ArtiomOvechko.RPG.Desktop.Core.Environment;
using ArtiomOvechko.RPG.Desktop.Core.Helpers;
using ArtiomOvechko.RPG.Desktop.Core.Animation;

namespace ArtiomOvechko.RPG.Desktop.Core.Weapon
{
    [Serializable]
    public class Knife: BaseWeapon
    {
        private bool _canAttack = true;

        public Knife()
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
                ExecutionHelper.GetNew.ExecuteWithDelayAsync(() => { _canAttack = true; }, WeaponSettings.KnifeCoolDown);

                var actor = new Actor.Knife(new Stats.Point(attacker.Position.X, attacker.Position.Y), attacker, attacker.Environment);
                var projectile = new Projectile(actor, attacker, direction, WeaponSettings.KnifeRange, WeaponSettings.KnifeSound);
                
                attacker.Environment.AddInstance(projectile);
            }

            return result;
        }
    }
}
