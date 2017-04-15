using System;

using ArtiomOvechko.RPG.Core.Enum;
using ArtiomOvechko.RPG.Core.Interfaces.Animation;

namespace ArtiomOvechko.RPG.Core.Animation
{
    public class TreeAnimation : IActorAnimation
    {
        public Uri GetIdleAnimation(Direction direction)
        {
            return new Uri(@"pack://application:,,,/ArtiomOvechko.RPG.Common;Component/Resources/Images/Actors/Obstacles/Tree.png");
        }

        public Uri GetMovingAnimation(Direction direction)
        {
            return new Uri(@"pack://application:,,,/ArtiomOvechko.RPG.Common;Component/Resources/Images/Actors/Obstacles/Tree.png");
        }
    }
}
