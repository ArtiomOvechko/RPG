using System;

using ArtiomOvechko.RPG.Core.Interfaces.Animation;
using ArtiomOvechko.RPG.Core.Enum;


namespace ArtiomOvechko.RPG.Core.Animation
{
    public class ThiefAnimation : IActorAnimation
    {
        public Uri GetIdleAnimation(Direction direction)
        {
            return null;
            switch (direction)
            {
                case Direction.Up:
                    return new Uri(@"pack://application:,,,/ArtiomOvechko.RPG.Common;Component/Resources/Images/Actors/Thief/ThiefIdle.png");
                default:
                    return new Uri(@"pack://application:,,,/ArtiomOvechko.RPG.Common;Component/Resources/Images/Actors/Thief/ThiefIdle.png");
            }

            throw new NotImplementedException();
        }

        public Uri GetMovingAnimation(Direction direction)
        {
            return null;
            switch (direction)
            {
                case Direction.Up:
                    return new Uri(@"pack://application:,,,/ArtiomOvechko.RPG.Common;Component/Resources/Images/Actors/Thief/ThiefMoveLeft.gif");
                default:
                    return new Uri(@"pack://application:,,,/ArtiomOvechko.RPG.Common;Component/Resources/Images/Actors/Thief/ThiefMoveLeft.gif");
            }

            throw new NotImplementedException();
        }
    }
}
