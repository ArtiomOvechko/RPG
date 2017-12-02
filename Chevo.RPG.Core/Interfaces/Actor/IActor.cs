using Chevo.RPG.Core.Enum;
using Chevo.RPG.Core.Interfaces.Interaction;
using Chevo.RPG.Core.Interfaces.Inventory;
using Chevo.RPG.Core.Interfaces.Weapon;
using Chevo.RPG.Core.Stats;

using System.ComponentModel;
using System;


namespace Chevo.RPG.Core.Interfaces.Actor
{
    /// <summary>
    /// Game core agent (behaviorless puppet)
    /// </summary>
    public interface IActor: INotifyPropertyChanged
    {
        /// <summary>
        /// Moving or idle
        /// </summary>
        State CurrentState { get; }

        /// <summary>
        /// Path to animation file
        /// </summary>
        Uri CurrentAnimation { get; }

        /// <summary>
        /// Represents direction of actor (up, right, down, left)
        /// </summary>
        Direction CurrentDirection { get; }
        
        /// <summary>
        /// Currently used weapon
        /// </summary>
        IWeapon Weapon { get; }

        /// <summary>
        /// Actor items
        /// </summary>
        IInventory Inventory { get; }

        /// <summary>
        /// Coordinates
        /// </summary>
        Point Position { get; set; }

        /// <summary>
        /// Health, speed, size and etc
        /// </summary>
        IStats Stats { get; set; }

        /// <summary>
        /// Enable moving
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        void StartMove(Direction direction);

        /// <summary>
        /// Try move and return distance passed
        /// </summary>
        int Move();

        /// <summary>
        /// Disable moving and switch animation
        /// </summary>
        void StopMove();

        /// <summary>
        /// Attemp to interact with nearest instances
        /// </summary>
        /// <param name="interactor">Interaction handler</param>
        void TryInteract(IInteractionHandler interactor);

        /// <summary>
        /// Try to break interaction process
        /// </summary>
        /// <param name="interactor">Interaction handler</param>
        void TryStopInteraction(IInteractionHandler interactor);

        /// <summary>
        /// Use weapon to attack in some direction
        /// </summary>
        void Attack();

        /// <summary>
        /// Action after collision with projectile
        /// </summary>
        /// <param name="attackerStats">Attacker's parameters</param>
        void HandleAttack(IStats attackerStats);

        /// <summary>
        /// Change current weapon
        /// </summary>
        /// <param name="weaponItem"></param>
        void EquipWeapon(IWeaponItem weaponItem);

        /// <summary>
        /// Set current weapon to null
        /// </summary>
        void UnequipWeapon();
    }
}
