using System;

using Chevo.RPG.Core.Interfaces.Animation;
using Chevo.RPG.Core.Enum;


namespace Chevo.RPG.Core.Animation
{
    [Serializable]
    public class ThiefAnimation : IActorAnimation
    {
        private const string IdleLeft = @"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Thief/ThiefIdleLeft.gif";

        private const string MovesLeft = @"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Thief/ThiefMoveLeft.gif";

        private const string IdleRight = @"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Thief/ThiefIdleRight.gif";

        private const string MovesRight = @"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Thief/ThiefMoveRight.gif";

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
