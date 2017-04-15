using ArtiomOvechko.RPG.Core.Interfaces.Collision;
using ArtiomOvechko.RPG.Core.Interfaces.Actor;

using System.Linq;
using ArtiomOvechko.RPG.Core.Helpers;
using ArtiomOvechko.RPG.Core.Enum;
using ArtiomOvechko.RPG.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Core.Behavior.Projectile;

namespace ArtiomOvechko.RPG.Core.Collision
{
    public class DefaultCollisionResolver : ICollisionResolver
    {
        public virtual int ResolveCollision(IActor sender, Direction direction)
        {
            var tempStepLength = sender.Specs.StepLenght;
            int offset = 0;
            while (tempStepLength-- != 0)
            {
                var expectedSpec = GetExpectedSpecs(sender, direction, tempStepLength);
                var collided = sender.Surrounding.FirstOrDefault(x => Collider.Colliding(x.Actor.Specs, expectedSpec) && sender != x.Actor && !(x is Projectile));
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
                    break;
                }
            }

            return offset;
        }

        protected ISpec GetExpectedSpecs(IActor sender, Direction direction, int stepLength)
        {
            ISpec expectedSpec = null;
            switch (direction)
            {
                case Direction.Up:
                    expectedSpec = new Spec.Spec(sender.Specs.XPos, sender.Specs.YPos - stepLength, sender.Specs.Size);
                    expectedSpec.StepLenght = sender.Specs.StepLenght;
                    break;
                case Direction.Right:
                    expectedSpec = new Spec.Spec(sender.Specs.XPos + stepLength, sender.Specs.YPos, sender.Specs.Size);
                    expectedSpec.StepLenght = sender.Specs.StepLenght;
                    break;
                case Direction.Down:
                    expectedSpec = new Spec.Spec(sender.Specs.XPos, sender.Specs.YPos + stepLength, sender.Specs.Size);
                    expectedSpec.StepLenght = sender.Specs.StepLenght;
                    break;
                case Direction.Left:
                    expectedSpec = new Spec.Spec(sender.Specs.XPos - stepLength, sender.Specs.YPos, sender.Specs.Size);
                    expectedSpec.StepLenght = sender.Specs.StepLenght;
                    break;
            }
            return expectedSpec;
        }
    }
}
