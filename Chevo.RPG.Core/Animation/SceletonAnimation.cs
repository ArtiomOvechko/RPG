using Chevo.RPG.Core.Enum;
using Chevo.RPG.Core.Interfaces.Animation;

using System;


namespace Chevo.RPG.Core.Animation
{
    [Serializable]
    public class SceletonAnimation : IActorAnimation
    {
        private const string IdleLeft = @"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Sceleton/SceletonLeftIdle.gif";

        private const string MovesLeft = @"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Sceleton/SceletonMovesLeft.gif";

        private const string IdleRight = @"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Sceleton/SceletonIdleRight.gif";

        private const string MovesRight = @"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Sceleton/SceletonMovesRight.gif";        

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
