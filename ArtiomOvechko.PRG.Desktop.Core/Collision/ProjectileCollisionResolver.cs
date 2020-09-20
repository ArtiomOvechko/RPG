using ArtiomOvechko.RPG.Desktop.Core.Enum;
using ArtiomOvechko.RPG.Desktop.Core.Environment;
using ArtiomOvechko.RPG.Desktop.Core.Helpers;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Desktop.Core.Behavior.Projectile;

using System.Linq;
using System;
using ArtiomOvechko.RPG.Desktop.Core.Behavior.StaticObject;

namespace ArtiomOvechko.RPG.Desktop.Core.Collision
{
    public class ProjectileCollisionResolver: DefaultCollisionResolver
    {
        private IActor _creator;
        private IActor _owner;

        /// <summary>
        /// Do nothing
        /// </summary>
        /// <param name="attackerStats">Doesn't matter</param>
        public override void HandleAttack(IStats attackerStats) { }

        public override int ResolveCollision(Direction direction)
        {
            IEnvironmentContainer environment = _owner.Environment;
            int offset = 0;
            var expectedSpec = GetExpectedSpecs(_owner, direction, _owner.Stats.StepLength);
            var collided = environment.Instances.FirstOrDefault(instance =>
                instance != null && Collider.Colliding(new CollisionModel(instance.Actor.Stats.Size, instance.Actor.Position.X, instance.Actor.Position.Y), expectedSpec) &&
                _owner != instance.Actor && _creator != instance.Actor && !(instance is Projectile) && !(instance is MovableObjectBehavior));
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
            }
            else
            {
                var behavior = environment.Instances.FirstOrDefault(x => x.Actor == _owner);
                environment.RemoveInstance(behavior);

                collided.Actor.HandleAttack(_owner.Stats);
            }

            return Math.Abs(offset);
        }

        public ProjectileCollisionResolver(IActor creator, IActor owner): base(owner)
        {
            _creator = creator;
            _owner = owner;
        }
    }
}
