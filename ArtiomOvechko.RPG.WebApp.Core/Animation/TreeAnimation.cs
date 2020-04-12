using System;

using Chevo.RPG.WebApp.Core.Enum;
using Chevo.RPG.WebApp.Core.Interfaces.Animation;

namespace Chevo.RPG.WebApp.Core.Animation
{
    [Serializable]
    public class TreeAnimation : IActorAnimation
    {
        public Uri GetIdleAnimation(Direction direction, Uri currentAnimation)
        {
            return new Uri(@"pack://application:,,,/Chevo.RPG.WebApp.Common;Component/Resources/Images/Obstacles/Tree.png");
        }

        public Uri GetMovingAnimation(Direction direction, Uri currentAnimation)
        {
            return new Uri(@"pack://application:,,,/Chevo.RPG.WebApp.Common;Component/Resources/Images/Obstacles/Tree.png");
        }
    }
}
