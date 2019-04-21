using Chevo.RPG.Core.Enum;
using System;
using System.Windows.Media.Imaging;

namespace Chevo.RPG.Core.Interfaces.Animation
{
    public interface IActorAnimation
    {
        Uri GetMovingAnimation(Direction direction, Uri currentAnimation);
        Uri GetIdleAnimation(Direction direction, Uri currentAnimation);
    }
}
