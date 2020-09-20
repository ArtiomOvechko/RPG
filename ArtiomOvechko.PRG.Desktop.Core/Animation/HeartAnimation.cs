using System;

using ArtiomOvechko.RPG.Desktop.Core.Enum;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Animation;

namespace ArtiomOvechko.RPG.Desktop.Core.Animation
{
    [Serializable]
    public class HeartAnimation : IActorAnimation
    {
        public Uri GetIdleAnimation(Direction direction, Uri currentAnimation)
        {
            return new Uri(@"/resources/images/actors/heart/NormalHeart.gif");
        }

        public Uri GetMovingAnimation(Direction direction, Uri currentAnimation)
        {
            return new Uri(@"/resources/images/actors/heart/NormalHeart.gif");
        }
    }
}
