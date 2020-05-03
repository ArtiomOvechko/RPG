using System;

using ArtiomOvechko.RPG.Mono.Core.Enum;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Animation;

namespace ArtiomOvechko.RPG.Mono.Core.Animation
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
