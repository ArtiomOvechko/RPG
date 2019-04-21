using System;

using Chevo.RPG.Core.Interfaces.Animation;
using Chevo.RPG.Core.Enum;


namespace Chevo.RPG.Core.Animation
{
    [Serializable]
    public class KnifeAnimation : IActorAnimation
    {
        public Uri GetIdleAnimation(Direction direction, Uri currentAnimation)
        {
            switch (direction)
            {
                default:
                case Direction.Up:
                    return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Knife/DaggerUp.gif");
                case Direction.Right:
                    return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Knife/DaggerRight.gif");
                case Direction.Down:
                    return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Knife/DaggerDown.gif");
                case Direction.Left:
                    return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Knife/DaggerLeft.gif");
            }
        }

        public Uri GetMovingAnimation(Direction direction, Uri currentAnimation)
        {
            switch (direction)
            {
                default:
                case Direction.Up:
                    return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Knife/DaggerUp.gif");
                case Direction.Right:
                    return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Knife/DaggerRight.gif");
                case Direction.Down:
                    return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Knife/DaggerDown.gif");
                case Direction.Left:
                    return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Knife/DaggerLeft.gif");
            }
        }
    }
}
