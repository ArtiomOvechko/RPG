using Chevo.RPG.WebApp.Core.Enum;
using Chevo.RPG.WebApp.Core.Interfaces.Animation;

using System;


namespace Chevo.RPG.WebApp.Core.Animation
{
    [Serializable]
    public class SceletonAnimation : IActorAnimation
    {
        private const string IdleLeft = @"/resources/images/actors/sceleton/SceletonLeftIdle.gif";

        private const string MovesLeft = @"/resources/images/actors/sceleton/SceletonMovesLeft.gif";

        private const string IdleRight = @"/resources/images/actors/sceleton/SceletonIdleRight.gif";

        private const string MovesRight = @"/resources/images/actors/sceleton/SceletonMovesRight.gif";        

        public Uri GetIdleAnimation(Direction direction, Uri currentAnimation)
        {
            switch (direction)
            {
                case Direction.Right:
                    return new Uri(IdleRight);
                case Direction.Left:
                    return new Uri(IdleLeft);
                default:
                    return (GetIdleAnimation(GetCurrentAnimationDirection(currentAnimation), currentAnimation));
            }
        }

        public Uri GetMovingAnimation(Direction direction, Uri currentAnimation)
        {
            switch (direction)
            {
                case Direction.Right:
                    return new Uri(MovesRight);
                case Direction.Left:
                    return new Uri(MovesLeft);
                default:
                    return (GetMovingAnimation(GetCurrentAnimationDirection(currentAnimation), currentAnimation));
            }
        }

        private Direction GetCurrentAnimationDirection(Uri currentAnimation)
        {
            switch (currentAnimation?.ToString() ?? string.Empty)
            {
                default:
                case IdleLeft:
                case MovesLeft:
                    return Direction.Left;
                case IdleRight:
                case MovesRight:
                    return Direction.Right;
            }
        }
    }
}
