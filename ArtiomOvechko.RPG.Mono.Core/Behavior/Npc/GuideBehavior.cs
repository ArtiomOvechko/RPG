using ArtiomOvechko.RPG.Mono.Core.Environment;
using ArtiomOvechko.RPG.Mono.Core.Helpers;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Interaction;

using System;
using System.Linq;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Inventory;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Weapon;

namespace ArtiomOvechko.RPG.Mono.Core.Behavior.Npc
{
    [Serializable]
    public class GuideBehavior : BaseBehavior, IInstance
    {
        public GuideBehavior(IActor actor): base()
        {
            _currentActor = actor;
        }

        private string _currentMessage;
        private int _interactionsCount = 6;
        private bool _interacted = false;
        private bool _attacked = false;
        private string[] _phrases = new string[] { "Oh, hello!", "New in here, aren't you?", "Use left mouse button to attack, but don't even try to test in on me!", "DONT.", "EVEN.", "TRY." };

        public string GetMessage()
        {
            if (!_attacked)
            {
                if (_currentMessage == null)
                {
                    _interacted = true;
                    var index = _interactionsCount++ % _phrases.Length;
                    var result = _phrases[index];
                    return result;
                }
                else
                {
                    var result = _currentMessage;
                    _currentMessage = null;
                    return result;
                }
            }

            return null;
        }

        public override void ProcessCurrentState()
        {
            base.ProcessCurrentState(); 
            
            if (_currentActor.IsDamaged)
            {
                _attacked = true;
            }
            
            if (!_interacted && !_attacked)
            {
                var player = _currentActor?.Environment.Instances.FirstOrDefault(x => (x?.IsPlayer ?? false)
                    && Collider.InRangeOfInteraction(new CollisionModel(x?.Actor), new CollisionModel(this.Actor)));
                if (player != null)
                {
                    _currentMessage = "Heya! Wait!";
                    this.Actor.InteractionHandler.Messenger.WriteMessage(this);
                }
            }
            
            if (_attacked)
            {
                if (_currentActor.Weapon == null)
                {
                    IWeaponItem weapon = (IWeaponItem)_currentActor.Inventory.Items.FirstOrDefault(x => x.Equippable);
                    _currentActor.EquipWeapon(weapon);
                }

                _currentActor.Attack();
            }
        }
    }
}
