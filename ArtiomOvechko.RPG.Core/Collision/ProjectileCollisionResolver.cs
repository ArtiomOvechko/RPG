using ArtiomOvechko.RPG.Core.Enum;
using ArtiomOvechko.RPG.Core.Helpers;
using ArtiomOvechko.RPG.Core.Interfaces.Actor;

using System.Linq;

namespace ArtiomOvechko.RPG.Core.Collision
{
    public class ProjectileCollisionResolver: DefaultCollisionResolver
    {
        private IActor _creator;

        public override int ResolveCollision(IActor sender, Direction direction)
        { 
            int offset = 0;
            var expectedSpec = GetExpectedSpecs(sender, direction, sender.Specs.StepLenght);
            var collided = sender.Surrounding.FirstOrDefault(x => Collider.Colliding(x.Actor.Specs, expectedSpec) && sender != x.Actor && x.Actor != _creator);
            if (collided == null)
            {
                switch (direction)
                {
                    case Direction.Down:
                    case Direction.Up:
                        offset = expectedSpec.YPos - sender.Specs.YPos;
                        break;
                    case Direction.Right:
                    case Direction.Left:
                        offset = expectedSpec.XPos - sender.Specs.XPos;
                        break;
                }
                sender.Specs = expectedSpec;
            }
            else
            {
                var behavior =  sender.Surrounding.FirstOrDefault(x => x.Actor == sender);
                sender.Surrounding.Remove(behavior);

                collided.Actor.Hit(sender.Specs);
            }

            return offset;
        }

        public ProjectileCollisionResolver(IActor creator)
        {
            _creator = creator;
        }
    }
}
