using System;

namespace Chevo.RPG.WebApp.Core.Stats
{
    public class Effect
    {
        public EffectType Type { get; }
        
        public DateTime EndTime { get; }
        
        public bool IsPermanent { get; }

        public Effect(EffectType type, TimeSpan duration)
        {
            Type = type;
            IsPermanent = false;
            EndTime = DateTime.Now.AddMilliseconds(duration.TotalMilliseconds);
        }

        public Effect(EffectType type)
        {
            Type = type;
            IsPermanent = true;
        }
    }
    
    public enum EffectType
    {
        Damage,
        Stun,
        Burn,
        Freeze,
        Poison,
        HealthChanged,
        Attacking,
        Talking
    }
}