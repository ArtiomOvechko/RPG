using ArtiomOvechko.RPG.Desktop.Core.Enum;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Interaction;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Inventory;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Weapon;
using ArtiomOvechko.RPG.Desktop.Core.Stats;

using System.ComponentModel;
using System;
using ArtiomOvechko.RPG.Desktop.Core.Environment;


namespace ArtiomOvechko.RPG.Desktop.Core.Interfaces.Actor
{
    /// <summary>
    /// Game core agent (behaviorless puppet)
    /// </summary>
    public interface IActor: INotifyPropertyChanged
    {
        public bool IsInteractive { get; }
        
        public bool IsDamaged { get; }
        
        public bool IsHealthBarShown { get; }
        
        public bool IsTalking { get; }
        
        public bool IsAttacking { get; }
        
        /// <summary>
        /// Current environment of the instance
        /// </summary>
        IEnvironmentContainer Environment { get; }
        
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
        /// Represents aiming direction of actor (up, right, down, left)
        /// It has priority over common direction in case when actors have a weapon equipped
        /// </summary>
        Direction CurrentAimDirection { get; set; }

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
        /// Communication module
        /// </summary>
        IInteractionHandler InteractionHandler { get; }
        
        /// <summary>
        /// Position of the health bar
        /// </summary>
        Point HealthBarPosition { get; }
        
        Point WeaponPosition { get; }

        /// <summary>
        /// Health, speed, size and etc
        /// </summary>
        IStats Stats { get; set; }

        /// <summary>
        /// Handle effects
        /// </summary>
        void ProcessCurrentState();

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
        void TryInteract();

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
