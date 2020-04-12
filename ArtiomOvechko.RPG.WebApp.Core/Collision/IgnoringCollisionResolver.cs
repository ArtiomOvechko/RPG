using Chevo.RPG.WebApp.Core.Enum;
using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using System;

namespace Chevo.RPG.WebApp.Core.Collision
{
    public class IgnoringCollisionResolver : DefaultCollisionResolver
    {
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

            return Math.Abs(offset);
        }

        public IgnoringCollisionResolver(IActor owner): base(owner)
        {
            _owner = owner;
        }
    }
}
