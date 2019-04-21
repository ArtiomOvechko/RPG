using System;

using Chevo.RPG.Core.Enum;
using Chevo.RPG.Core.Interfaces.Animation;

namespace Chevo.RPG.Core.Animation
{
    [Serializable]
    public class DungeonStoneWallAnimation : IActorAnimation
    {
        public Uri GetIdleAnimation(Direction direction, Uri currentAnimation)
        {
            return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/Obstacles/DungeonStoneWall/Wall.gif");
        }

        public Uri GetMovingAnimation(Direction direction, Uri currentAnimation)
        {
            return new Uri(@"pack://application:,,,/Chevo.RPG.Common;Component/Resources/Images/DungeonStoneWall/Wall.gif");
        }
    }
}
