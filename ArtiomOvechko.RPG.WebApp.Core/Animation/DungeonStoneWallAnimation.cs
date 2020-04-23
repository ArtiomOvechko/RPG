using System;

using Chevo.RPG.WebApp.Core.Enum;
using Chevo.RPG.WebApp.Core.Interfaces.Animation;

namespace Chevo.RPG.WebApp.Core.Animation
{
    [Serializable]
    public class DungeonStoneWallAnimation : IActorAnimation
    {
        public Uri GetIdleAnimation(Direction direction, Uri currentAnimation)
        {
            return new Uri(@"/resources/images/obstacles/dungeonStoneWall/Wall.gif");
        }

        public Uri GetMovingAnimation(Direction direction, Uri currentAnimation)
        {
            return new Uri(@"/resources/images/obstacles/dungeonStoneWall/Wall.gif");
        }
    }
}
