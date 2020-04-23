using System;

using Chevo.RPG.WebApp.Core.Enum;
using Chevo.RPG.WebApp.Core.Interfaces.Animation;

namespace Chevo.RPG.WebApp.Core.Animation
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
