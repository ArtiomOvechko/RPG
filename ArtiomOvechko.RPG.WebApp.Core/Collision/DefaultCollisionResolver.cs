using System.Linq;

using Chevo.RPG.WebApp.Core.Interfaces.Collision;
using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using Chevo.RPG.WebApp.Core.Helpers;
using Chevo.RPG.WebApp.Core.Enum;
using Chevo.RPG.WebApp.Core.Behavior.Projectile;
using Chevo.RPG.WebApp.Core.Environment;
using Chevo.RPG.WebApp.Core.Factories;
using System;
using Chevo.RPG.WebApp.Core.Behavior.StaticObject;

namespace Chevo.RPG.WebApp.Core.Collision
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
            IEnvironmentContainer environment = _owner.Environment;
            environment.AddInstance(DamageAnimationFactory.GetHeart(_owner));
            if (_owner.Stats.Lives.Count <= 0)
            {
                var ownerInstance = environment.Instances.FirstOrDefault(x => x.Actor == _owner);
                if (ownerInstance != null)
                {
                    environment.RemoveInstance(ownerInstance);
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
                var collided = _owner.Environment.Instances.FirstOrDefault(instance => 
                    instance != null && Collider.Colliding(new CollisionModel(instance.Actor.Stats.Size, instance.Actor.Position.X, instance.Actor.Position.Y), expectedSpec) &&
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
