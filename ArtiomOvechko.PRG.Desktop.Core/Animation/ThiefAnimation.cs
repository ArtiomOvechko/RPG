using System;

using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Animation;
using ArtiomOvechko.RPG.Desktop.Core.Enum;


namespace ArtiomOvechko.RPG.Desktop.Core.Animation
{
    [Serializable]
    public class ThiefAnimation : IActorAnimation
    {
        private const string IdleLeft = @"/resources/images/actors/thief/ThiefIdleLeft.gif";

        private const string MovesLeft = @"/resources/images/actors/thief/ThiefMoveLeft.gif";

        private const string IdleRight = @"/resources/images/actors/thief/ThiefIdleRight.gif";

        private const string MovesRight = @"/resources/images/actors/thief/ThiefMoveRight.gif";

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
