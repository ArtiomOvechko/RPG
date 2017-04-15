using Chevo.RPG.Core.Enum;
using Chevo.RPG.Core.Interfaces.Animation;

using System;


namespace Chevo.RPG.Core.Animation
{
    [Serializable]
    public class SceletonAnimation : IActorAnimation
    {
        public Uri GetIdleAnimation(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                case Direction.Right:
                    return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Sceleton/SceletonIdleRight.gif");
                case Direction.Down:
                case Direction.Left:
                    return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Sceleton/SceletonLeftIdle.gif");
            }

            throw new NotImplementedException();
        }

        public Uri GetMovingAnimation(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                case Direction.Right:
                    return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Sceleton/SceletonMovesRight.gif");
                case Direction.Down:
                case Direction.Left:
                    return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Sceleton/SceletonMovesLeft.gif");
            }

            throw new NotImplementedException();
        }
    }
}
