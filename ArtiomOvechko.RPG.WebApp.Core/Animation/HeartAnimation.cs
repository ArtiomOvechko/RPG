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
            return new Uri(@"pack://application:,,,/Chevo.RPG.WebApp.Common;Component/Resources/Images/Actors/Heart/NormalHeart.gif");
        }

        public Uri GetMovingAnimation(Direction direction, Uri currentAnimation)
        {
            return new Uri(@"pack://application:,,,/Chevo.RPG.WebApp.Common;Component/Resources/Images/Actors/Heart/NormalHeart.gif");
        }
    }
}
