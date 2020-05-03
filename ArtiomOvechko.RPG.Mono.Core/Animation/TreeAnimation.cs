using System;

using ArtiomOvechko.RPG.Mono.Core.Enum;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Animation;

namespace ArtiomOvechko.RPG.Mono.Core.Animation
{
    [Serializable]
    public class TreeAnimation : IActorAnimation
    {
        public Uri GetIdleAnimation(Direction direction, Uri currentAnimation)
        {
            return new Uri(@"pack://application:,,,/ArtiomOvechko.RPG.Mono.Common;Component/Resources/Images/Obstacles/Tree.png");
        }

        public Uri GetMovingAnimation(Direction direction, Uri currentAnimation)
        {
            return new Uri(@"pack://application:,,,/ArtiomOvechko.RPG.Mono.Common;Component/Resources/Images/Obstacles/Tree.png");
        }
    }
}
