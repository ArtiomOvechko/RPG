using ArtiomOvechko.RPG.Desktop.Core.Enum;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Actor;
using System;

namespace ArtiomOvechko.RPG.Desktop.Core.Interfaces.Weapon
{
    public interface IWeapon
    {
        bool Attack(IActor attacker, Direction direction);

        Uri CurrentAnimation { get; }

        int Size { get; }
        
        public int Cooldown { get; }

        Direction CurrentDirection { get; set; }

        void SetSize(IActor owner);
    }
}
