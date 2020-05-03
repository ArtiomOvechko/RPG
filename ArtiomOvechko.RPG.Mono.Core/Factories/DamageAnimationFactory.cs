using ArtiomOvechko.RPG.Mono.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Mono.Core.Actor;
using ArtiomOvechko.RPG.Mono.Core.Behavior.Projectile;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Instance;

namespace ArtiomOvechko.RPG.Mono.Core.Factories
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
