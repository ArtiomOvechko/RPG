using System;

using ArtiomOvechko.RPG.Core.Enum;


namespace ArtiomOvechko.RPG.Core.Interfaces.Animation
{
    public interface IActorAnimation
    {
        Uri GetMovingAnimation(Direction direction);
        Uri GetIdleAnimation(Direction direction);
    }
}
