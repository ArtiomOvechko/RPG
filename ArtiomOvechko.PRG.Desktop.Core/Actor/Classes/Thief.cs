using System;

using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Desktop.Core.Animation;
using ArtiomOvechko.RPG.Desktop.Core.Stats;
using ArtiomOvechko.RPG.Desktop.Core.Collision;
using ArtiomOvechko.RPG.Desktop.Core.Environment;
using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Inventory;

namespace ArtiomOvechko.RPG.Desktop.Core.Actor
{
    [Serializable]
    public class Thief: BaseActor
    {
        public Thief(IWeaponItem weapon, Point initialPosition, IEnvironmentContainer environmentContainer) 
            : base(weapon, initialPosition, environmentContainer)
        {
            Stats = new DefaultStats(Common.Settings.ActorSettings.DefaultSize, 30, 9, Common.Settings.ActorSettings.ThiefStepLength);
            _animation = new ThiefAnimation();
            _collisionResolver = new DefaultCollisionResolver(this);
            _isInteractive = true;
        }
    }
}
