using System;

using Chevo.RPG.Core.Enum;
using Chevo.RPG.Core.Interfaces.Animation;

namespace Chevo.RPG.Core.Animation
{
    [Serializable]
    public class HeartAnimation : IActorAnimation
    {
        public Uri GetIdleAnimation(Direction direction)
        {
            return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Heart/NormalHeart.gif");
        }

        public Uri GetMovingAnimation(Direction direction)
        {
            return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Actors/Heart/NormalHeart.gif");
        }
    }
}
