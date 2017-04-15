using System;
using System.Collections.Generic;

using ArtiomOvechko.RPG.Core.Interfaces.Animation;
using ArtiomOvechko.RPG.Core.Enum;
using ArtiomOvechko.RPG.Core.Interfaces.Weapon;
using ArtiomOvechko.RPG.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Core.Interfaces.Interaction;


namespace ArtiomOvechko.RPG.Core.Interfaces.Actor
{
    public interface IActor
    {
        ISpec Specs { get; set; }
        IWeapon Weapon { get; }
        IActorAnimation Animation { get; set; }
        ICollection<IInstance> Surrounding { get; }
        Direction CurrentDirection { get; set; }
        State CurrentState { get; set; }

        Uri CurrentAnimation { get; }

        int Move(Direction direction);

        void TryInteract(IInteractionHandler interactor);

        void TryStopInteraction(IInteractionHandler interactor);

        void Attack(Direction direction);

        void Hit(ISpec attackerStats);
    }
}
