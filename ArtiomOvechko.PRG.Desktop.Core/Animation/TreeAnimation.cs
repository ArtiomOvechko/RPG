using System;

using ArtiomOvechko.RPG.Desktop.Core.Enum;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Animation;

namespace ArtiomOvechko.RPG.Desktop.Core.Animation
{
    [Serializable]
    public class TreeAnimation : IActorAnimation
    {
        public Uri GetIdleAnimation(Direction direction, Uri currentAnimation)
        {
            return new Uri(@"pack://application:,,,/ArtiomOvechko.RPG.Desktop.Common;Component/Resources/Images/Obstacles/Tree.png");
        }

        public Uri GetMovingAnimation(Direction direction, Uri currentAnimation)
        {
            return new Uri(@"pack://application:,,,/ArtiomOvechko.RPG.Desktop.Common;Component/Resources/Images/Obstacles/Tree.png");
        }
    }
}
