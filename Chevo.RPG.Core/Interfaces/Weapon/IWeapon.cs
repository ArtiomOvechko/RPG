using Chevo.RPG.Core.Enum;
using Chevo.RPG.Core.Interfaces.Actor;
using System;

namespace Chevo.RPG.Core.Interfaces.Weapon
{
    public interface IWeapon
    {
        void Attack(IActor attacker, Direction direction);

        Uri CurrentAnimation { get; }

        int Size { get; }

        Direction CurrentDirection { get; set; }

        void SetSize(IActor owner);
    }
}
