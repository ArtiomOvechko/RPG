using System;

using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Animation;
using ArtiomOvechko.RPG.Desktop.Core.Enum;


namespace ArtiomOvechko.RPG.Desktop.Core.Animation
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
                    return new Uri(@"/resources/images/actors/knife/DaggerUp.gif");
                case Direction.Right:
                    return new Uri(@"/resources/images/actors/knife/DaggerRight.gif");
                case Direction.Down:
                    return new Uri(@"/resources/images/actors/knife/DaggerDown.gif");
                case Direction.Left:
                    return new Uri(@"/resources/images/actors/knife/DaggerLeft.gif");
            }
        }

        public Uri GetMovingAnimation(Direction direction, Uri currentAnimation)
        {
            switch (direction)
            {
                default:
                case Direction.Up:
                    return new Uri(@"/resources/images/actors/knife/DaggerUp.gif");
                case Direction.Right:
                    return new Uri(@"/resources/images/actors/knife/DaggerRight.gif");
                case Direction.Down:
                    return new Uri(@"/resources/images/actors/knife/DaggerDown.gif");
                case Direction.Left:
                    return new Uri(@"/resources/images/actors/knife/DaggerLeft.gif");
            }
        }
    }
}
