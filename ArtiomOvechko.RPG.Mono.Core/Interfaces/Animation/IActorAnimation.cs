using ArtiomOvechko.RPG.Mono.Core.Enum;
using System;
//using System.Windows.Media.Imaging;

namespace ArtiomOvechko.RPG.Mono.Core.Interfaces.Animation
{
    public interface IActorAnimation
    {
        Uri GetMovingAnimation(Direction direction, Uri currentAnimation);
        Uri GetIdleAnimation(Direction direction, Uri currentAnimation);
    }
}
