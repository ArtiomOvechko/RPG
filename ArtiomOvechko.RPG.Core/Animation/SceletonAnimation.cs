using System;

using ArtiomOvechko.RPG.Core.Enum;
using ArtiomOvechko.RPG.Core.Interfaces.Animation;


namespace ArtiomOvechko.RPG.Core.Animation
{
    public class SceletonAnimation : IActorAnimation
    {
        public Uri GetIdleAnimation(Direction direction)
        {
            return null;
            switch (direction)
            {               
                case Direction.Right:
                    return new Uri(@"pack://application:,,,/ArtiomOvechko.RPG.Common;Component/Resources/Images/Actors/Sceleton/SceletonIdleRight.gif");
                default:
                case Direction.Left:
                    return new Uri(@"pack://application:,,,/ArtiomOvechko.RPG.Common;Component/Resources/Images/Actors/Sceleton/SceletonLeftIdle.gif");
            }

            throw new NotImplementedException();
        }

        public Uri GetMovingAnimation(Direction direction)
        {
            return null;
            switch (direction)
            {
                case Direction.Up:
                case Direction.Right:
                    return new Uri(@"pack://application:,,,/ArtiomOvechko.RPG.Common;Component/Resources/Images/Actors/Sceleton/SceletonMovesRight.gif");
                case Direction.Down:
                case Direction.Left:
                    return new Uri(@"pack://application:,,,/ArtiomOvechko.RPG.Common;Component/Resources/Images/Actors/Sceleton/SceletonMovesLeft.gif");
            }

            throw new NotImplementedException();
        }
    }
}
