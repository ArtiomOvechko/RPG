using System.Linq;

using Chevo.RPG.Core.Interfaces.Collision;
using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Core.Helpers;
using Chevo.RPG.Core.Enum;
using Chevo.RPG.Core.Behavior.Projectile;
using Chevo.RPG.Core.Environment;
using Chevo.RPG.Core.Factories;
using System;
using Chevo.RPG.Core.Behavior.StaticObject;

namespace Chevo.RPG.Core.Collision
{
    public class DefaultCollisionResolver : ICollisionResolver
    {
        private IActor _owner;

        public DefaultCollisionResolver(IActor owner)
        {
            _owner = owner;
        }

        public virtual void HandleAttack(IStats attackerStats)
        {
            _owner.Stats.LostLives(attackerStats.Damage);
            EnvironmentContainer.AddInstance(DamageAnimationFactory.GetHeart(_owner));
            if (_owner.Stats.Lives.Count <= 0)
            {
                var ownerInstance = EnvironmentContainer.Instances.FirstOrDefault(x => x.Actor == _owner);
                if (ownerInstance != null)
                {
                    EnvironmentContainer.RemoveInstance(ownerInstance);
                }
            }
        }

        public virtual int ResolveCollision(Direction direction)
        {
            var tempStepLength = _owner.Stats.StepLenght;
            int offset = 0;
            while (tempStepLength != 0)
            {
                var expectedSpec = GetExpectedSpecs(_owner, direction, tempStepLength);
                var collided = EnvironmentContainer.Instances.FirstOrDefault(instance => 
                    Collider.Colliding(new CollisionModel(instance.Actor.Stats.Size, instance.Actor.Position.X, instance.Actor.Position.Y), expectedSpec) &&
                    _owner != instance.Actor && !(instance is Projectile) && !(instance is MovableObjectBehavior));
                if (collided == null)
                {
                    switch (direction)
                    {
                        case Direction.Down:
                        case Direction.Up:
                            offset = expectedSpec.Y - _owner.Position.Y;
                            break;
                        case Direction.Right:
                        case Direction.Left:
                            offset = expectedSpec.X - _owner.Position.X;
                            break;
                    }
                    _owner.Position = new Stats.Point(expectedSpec.X, expectedSpec.Y);
                    break;
                }
                tempStepLength--;
            }

            return Math.Abs(offset);
        }

        protected CollisionModel GetExpectedSpecs(IActor sender, Direction direction, int stepLength)
        {
            CollisionModel expectedSpec = null;
            switch (direction)
            {
                case Direction.Up:
                    expectedSpec = new CollisionModel(sender.Stats.Size, sender.Position.X, sender.Position.Y - stepLength);
                    break;
                case Direction.Right:
                    expectedSpec = new CollisionModel(sender.Stats.Size, sender.Position.X + stepLength, sender.Position.Y);
                    break;
                case Direction.Down:
                    expectedSpec = new CollisionModel(sender.Stats.Size, sender.Position.X, sender.Position.Y + stepLength);
                    break;
                case Direction.Left:
                    expectedSpec = new CollisionModel(sender.Stats.Size, sender.Position.X - stepLength, sender.Position.Y);
                    break;
            }
            return expectedSpec;
        }
    }
}
