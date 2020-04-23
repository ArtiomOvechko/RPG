using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using Chevo.RPG.WebApp.Core.Actor;
using Chevo.RPG.WebApp.Core.Behavior.Projectile;
using Chevo.RPG.WebApp.Core.Interfaces.Instance;

namespace Chevo.RPG.WebApp.Core.Factories
{
    public static class DamageAnimationFactory
    {
        public static IInstance GetHeart(IActor creator)
        {
            var actor = new BrokenHeart(new Stats.Point(creator.Position.X, creator.Position.Y), creator.Environment);
            return new Projectile(actor, creator, Enum.Direction.Up, Common.Settings.ActorSettings.BrokenHeartRange, Common.Settings.WeaponSettings.KnifeSound);
        }
        
        public static IInstance GetNumber(IActor creator, int damage)
        {
            var actor = new BrokenHeart(new Stats.Point(creator.Position.X, creator.Position.Y), creator.Environment);
            return new Projectile(actor, creator, Enum.Direction.Up, Common.Settings.ActorSettings.BrokenHeartRange, Common.Settings.WeaponSettings.KnifeSound);
        }
    }
}
