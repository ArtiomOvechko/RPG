using System;

using Chevo.RPG.Core.Interfaces.Animation;
using Chevo.RPG.Core.Enum;


namespace Chevo.RPG.Core.Animation
{
    [Serializable]
    public class ThiefAnimation : IActorAnimation
    {
        public Uri GetIdleAnimation(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                case Direction.Right:
                    return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Thief/ThiefIdleRight.gif");
                default:
                    return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Thief/ThiefIdleLeft.gif");
            }
        }

        public Uri GetMovingAnimation(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                case Direction.Right:
                    return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Thief/ThiefMoveRight.gif");
                default:
                    return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Thief/ThiefMoveLeft.gif");
            }
        }
    }
}
