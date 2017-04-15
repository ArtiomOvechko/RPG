using System;
using System.Windows.Media.Imaging;

using Chevo.RPG.Core.Enum;
using Chevo.RPG.Core.Interfaces.Animation;

namespace Chevo.RPG.Core.Animation
{
    [Serializable]
    public class TreeAnimation : IActorAnimation
    {
        public Uri GetIdleAnimation(Direction direction)
        {
            return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Obstacles/Tree.png");
        }

        public Uri GetMovingAnimation(Direction direction)
        {
            return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Obstacles/Tree.png");
        }
    }
}
