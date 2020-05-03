using System;

using ArtiomOvechko.RPG.Mono.Core.Enum;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Animation;

namespace ArtiomOvechko.RPG.Mono.Core.Animation
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
