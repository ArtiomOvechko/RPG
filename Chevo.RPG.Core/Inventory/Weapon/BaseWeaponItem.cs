using Chevo.RPG.Core.Interfaces.Actor;
using Chevo.RPG.Core.Interfaces.Inventory;
using Chevo.RPG.Core.Interfaces.Weapon;
using Chevo.RPG.Core.Stats;

using System;
using System.ComponentModel;


namespace Chevo.RPG.Core.Inventory.Weapon
{
    /// <summary>
    /// Use to store weapons in inventory
    /// </summary>
    public abstract class BaseWeaponItem : IWeaponItem
    {
        private bool _equipped;

        /// <summary>
        /// Weapon returned by "void Equip()" method
        /// </summary>
        protected IWeapon _weapon;

        /// <summary>
        /// Image or animation for weapon
        /// </summary>
        public Uri Animation { get; protected set; }

        /// <summary>
        /// Position in level
        /// </summary>
        public Point Position { get; private set; }

        /// <summary>
        /// Determines whether weapon is currently equipped
        /// </summary>
        public bool Equipped
        {
            get
            {
                return _equipped;
            }

            private set
            {
                _equipped = value;
            }
        }

        /// <summary>
        /// Determines whether item can be equipped
        /// </summary>
        public bool Equippable
        {
            get
            {
                return !Equipped;
            }
        }

        /// <summary>
        /// Determines whether weapon can be uequipped
        /// </summary>
        public bool Unequippable
        {
            get
            {
                return Equipped;
            }
        }

        /// <summary>
        /// Determines whether item can be discarded
        /// </summary>
        public bool Discardable
        {
            get
            {
                return !Equipped;
            }
        }

        /// <summary>
        /// Display name for weapon item
        /// </summary>
        public string Title { get; protected set; }

        /// <summary>
        /// Get weapon from item and mark it as equipped
        /// </summary>
        /// <returns></returns>
        public IWeapon Equip(IActor owner)
        {
            _equipped = true;
            OnPropertyChanged("Equippable");
            OnPropertyChanged("Unequippable");
            OnPropertyChanged("Discardable");
            _weapon.SetSize(owner);
            return _weapon;
        }

        /// <summary>
        /// Mark weapon as uneqipped
        /// </summary>
        public void Unequip()
        {
            _equipped = false;
            OnPropertyChanged("Equippable");
            OnPropertyChanged("Unequippable");
            OnPropertyChanged("Discardable");
        }

        public BaseWeaponItem(Point position)
        {
            Position = position;
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
