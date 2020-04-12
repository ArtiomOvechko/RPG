﻿using Chevo.RPG.WebApp.Core.Enum;
using Chevo.RPG.WebApp.Core.Environment;
using Chevo.RPG.WebApp.Core.Helpers;
using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using Chevo.RPG.WebApp.Core.Behavior.Projectile;

using System.Linq;
using System;
using Chevo.RPG.WebApp.Core.Behavior.StaticObject;

namespace Chevo.RPG.WebApp.Core.Collision
{
    public class ProjectileCollisionResolver: DefaultCollisionResolver
    {
        private IActor _creator;
        private IActor _owner;

        /// <summary>
        /// Do nothing
        /// </summary>
        /// <param name="attackerStats">No matter</param>
        public override void HandleAttack(IStats attackerStats) { }

        public override int ResolveCollision(Direction direction)
        { 
            int offset = 0;
            var expectedSpec = GetExpectedSpecs(_owner, direction, _owner.Stats.StepLenght);
            var collided = EnvironmentContainer.Instances.FirstOrDefault(instance =>
                Collider.Colliding(new CollisionModel(instance.Actor.Stats.Size, instance.Actor.Position.X, instance.Actor.Position.Y), expectedSpec) &&
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
                var behavior = EnvironmentContainer.Instances.FirstOrDefault(x => x.Actor == _owner);
                EnvironmentContainer.RemoveInstance(behavior);

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
