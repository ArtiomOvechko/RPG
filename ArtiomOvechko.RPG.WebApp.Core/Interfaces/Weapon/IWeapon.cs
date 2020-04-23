using Chevo.RPG.WebApp.Core.Enum;
using Chevo.RPG.WebApp.Core.Interfaces.Actor;
using System;

namespace Chevo.RPG.WebApp.Core.Interfaces.Weapon
{
    public interface IWeapon
    {
        bool Attack(IActor attacker, Direction direction);

        Uri CurrentAnimation { get; }

        int Size { get; }

        Direction CurrentDirection { get; set; }

        void SetSize(IActor owner);
    }
}
