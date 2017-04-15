using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Core.Actor;
using Chevo.RPG.Core.Behavior.Projectile;
using Chevo.RPG.Core.Interfaces.Instance;

namespace Chevo.RPG.Core.Factories
{
    public static class DamageAnimationFactory
    {
        public static IInstance GetHeart(IActor creator)
        {
            var actor = new BrokenHeart(new Stats.Point(creator.Position.X, creator.Position.Y));
            return new Projectile(actor, creator, Enum.Direction.Up, Common.Settings.ActorSettings.BrokenHeartRange, Common.Settings.WeaponSettings.KnifeSound);
        }
    }
}
