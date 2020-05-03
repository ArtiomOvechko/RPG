using ArtiomOvechko.RPG.Mono.Core.Enum;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Actor;
using System;

namespace ArtiomOvechko.RPG.Mono.Core.Interfaces.Weapon
{
    public interface IWeapon
    {
        bool Attack(IActor attacker, Direction direction);

        Uri CurrentAnimation { get; }

        int Size { get; }
        
        int Cooldown { get; }

        Direction CurrentDirection { get; set; }

        void SetSize(IActor owner);
    }
}
